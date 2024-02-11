using UnityEngine.Events;

/// <summary>
/// An event for alerting about detaches/attaches.
/// </summary>
[System.Serializable]
public class DetachEvent : UnityEvent<DetachEventParams> { }