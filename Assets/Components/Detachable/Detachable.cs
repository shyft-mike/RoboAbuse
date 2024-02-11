using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component that is detachable.
/// </summary>
public class Detachable : Moveable
{
    /// <summary>
    /// The event that fires on detach/attach.
    /// </summary>
    [SerializeField]
    public DetachEvent DetachEvent;

    /// <summary>
    /// The collection of points this detachable can attach to.
    /// </summary>
    public List<AttachPoint> AttachablePoints;

    /// <summary>
    /// The AttachPoint the detachable is currently attached to.
    /// </summary>
    public AttachPoint AttachedTo;

    /// <summary>
    /// The position of the detachable which connect to the attach point.
    /// </summary>
    public GameObject AttachPosition;

    /// <summary>
    /// The distance the AttachPosition and AttachablePoint can be apart before detaching.
    /// </summary>
    public float DetachThreshold = 3.0f;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the Detachable.
    /// </summary>
    public void Initialize()
    {
        if (DetachEvent == null)
        {
            DetachEvent = new DetachEvent();
        }

        Attach(AttachedTo);
    }

    void Update()
    {

    }

    /// <summary>
    /// When the mouse button is released, handle the attach/detach behavior.
    /// </summary>
    /// <param name="eventParams">The MouseEventParams.</param>
    new public void HandleMouseUp(MouseEventParams eventParams)
    {
        if (AttachedTo == null)
        {
            TryAttach();
        }
        else
        {
            TryDetach();
        }
    }

    /// <summary>
    /// Tries to attach to the first AttachablePoint within range.
    /// </summary>
    void TryAttach()
    {
        foreach (AttachPoint attachPoint in AttachablePoints)
        {
            if (AttachedTo != attachPoint && IsWithinAttachRange(attachPoint))
            {
                Attach(attachPoint);
                return;
            }
        }
    }

    /// <summary>
    /// Tries to detach from the current attached object.
    /// </summary>
    void TryDetach()
    {
        if (!IsWithinAttachRange(AttachedTo))
        {
            Detach();
        }
        else
        {
            // Snap back to the attach point if can't detach.
            Attach(AttachedTo);
        }
    }

    /// <summary>
    /// Gets the distance from the specified point to the object's attach position.
    /// </summary>
    /// <param name="positionToCheck">The point to check.</param>
    /// <returns>The distance between the specified point and the attach position.</returns>
    public float GetDistanceFromAttachPosition(Vector3 positionToCheck)
    {
        return Vector3.Distance(AttachPosition.transform.position, positionToCheck);
    }

    /// <summary>
    /// Checks if the given AttachPoint is within attach range.
    /// </summary>
    /// <param name="attachPoint">The AttachPoint to check.</param>
    /// <returns>True if within range, otherwise false.</returns>
    public bool IsWithinAttachRange(AttachPoint attachPoint)
    {
        return GetDistanceFromAttachPosition(attachPoint.transform.position) < DetachThreshold;
    }

    /// <summary>
    /// Attach to the given AttachPoint.
    /// </summary>
    /// <param name="attachPoint">The object to attach to.</param>
    void Attach(AttachPoint attachPoint)
    {
        AttachedTo = attachPoint;

        Vector3 offset = attachPoint.transform.position - AttachPosition.transform.position;
        transform.position += offset;
        transform.SetParent(attachPoint.transform); // Reparent to the attachpoint

        // Announce what got attached.
        DetachEvent.Invoke(new DetachEventParams(gameObject, false));
    }

    /// <summary>
    /// Detach from the current object.
    /// </summary>
    void Detach()
    {
        AttachedTo = null;
        gameObject.transform.SetParent(null);

        // Announce what got detached.
        DetachEvent.Invoke(new DetachEventParams(gameObject, true));
    }
}
