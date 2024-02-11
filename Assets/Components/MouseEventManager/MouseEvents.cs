using UnityEngine.Events;

/// <summary>
/// An event for when the mouse button is down.
/// </summary>
[System.Serializable]
public class MouseDownEvent : UnityEvent<MouseEventParams> { }

/// <summary>
/// An event for when the mouse is dragged.
/// </summary>
[System.Serializable]
public class MouseDragEvent : UnityEvent<MouseEventParams> { }

/// <summary>
/// An event for when the mouse button is released.
/// </summary>
[System.Serializable]
public class MouseUpEvent : UnityEvent<MouseEventParams> { }