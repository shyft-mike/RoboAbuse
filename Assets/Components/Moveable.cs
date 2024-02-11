using UnityEngine;

/// <summary>
/// A basic component for handling translation.
/// </summary>
public class Moveable : MonoBehaviour
{
    /// <summary>
    /// Whether the object is currently moving.
    /// </summary>
    protected bool _moving = false;

    /// <summary>
    /// The offset of the mouse cursor from the object.
    /// </summary>
    protected Vector3 _mouseOffset;

    /// <summary>
    /// Handles the mouse down event.
    /// </summary>
    /// <param name="eventParams">The MouseEventParams object.</param>
    public void HandleMouseDown(MouseEventParams eventParams)
    {
        _moving = true;
        _mouseOffset = transform.position - eventParams.MouseWorldPosition;
    }

    /// <summary>
    /// Handles the mouse drag event.
    /// </summary>
    /// <param name="eventParams">The MouseEventParams object.</param>
    public void HandleMouseDrag(MouseEventParams eventParams)
    {
        transform.position = eventParams.MouseWorldPosition + _mouseOffset;
    }

    /// <summary>
    /// Handles the mouse up event.
    /// </summary>
    /// <param name="eventParams">The MouseEventParams object.</param>
    public void HandleMouseUp(MouseEventParams eventParams)
    {
        _moving = false;
    }
}
