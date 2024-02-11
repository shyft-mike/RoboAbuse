
using UnityEngine;


/// <summary>
/// The parameters for a DetachEvent.
/// </summary>
public class DetachEventParams
{
    /// <summary>
    /// The game object from which the event occurred.
    /// </summary>
    public GameObject DetachedObject;

    /// <summary>
    /// Whether the object was detached.
    /// </summary>
    public bool IsDetached;

    public DetachEventParams(GameObject detachedObject, bool isDetached)
    {
        DetachedObject = detachedObject;
        IsDetached = isDetached;
    }
}
