using UnityEngine;

/// <summary>
/// The parameters for a MouseEvent.
/// </summary>
public class MouseEventParams
{
    /// <summary>
    /// The clicked object.
    /// </summary>
    public GameObject ClickedObject;

    /// <summary>
    /// The world position where the click occurred.
    /// </summary>
    public Vector3 MouseWorldPosition;

    public MouseEventParams(GameObject clickedObject, Vector3 mouseWorldPosition)
    {
        ClickedObject = clickedObject;
        MouseWorldPosition = mouseWorldPosition;
    }
}
