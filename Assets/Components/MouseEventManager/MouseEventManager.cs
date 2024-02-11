using UnityEngine;

/// <summary>
/// A component for dispatching mouse events.
/// </summary>
public class MouseEventManager : MonoBehaviour
{
    /// <summary>
    /// The event that fires on mouse down.
    /// </summary>
    [SerializeField]
    public MouseDownEvent MouseDownEvent;

    /// <summary>
    /// The event that fires on mouse drag.
    /// </summary>
    [SerializeField]
    public MouseDragEvent MouseDragEvent;

    /// <summary>
    /// The event that fires on mouse up.
    /// </summary>
    [SerializeField]
    public MouseUpEvent MouseUpEvent;

    /// <summary>
    /// The screen Z coordinate of the object.
    /// </summary>
    private float _screenZCoord;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the MouseEventManager.
    /// </summary>
    public void Initialize()
    {
        if (MouseDownEvent == null)
        {
            MouseDownEvent = new MouseDownEvent();
        }

        if (MouseDragEvent == null)
        {
            MouseDragEvent = new MouseDragEvent();
        }

        if (MouseUpEvent == null)
        {
            MouseUpEvent = new MouseUpEvent();
        }
    }

    void Update()
    {

    }

    /// <summary>
    /// Mouse down handler.
    /// </summary>
    void OnMouseDown()
    {
        _screenZCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        MouseDownEvent.Invoke(
            new MouseEventParams(
                gameObject,
                GetMouseWorldPosition()
            )
        );
    }

    /// <summary>
    /// Mouse drag handler.
    /// </summary>
    void OnMouseDrag()
    {
        MouseDragEvent.Invoke(
            new MouseEventParams(
                gameObject,
                GetMouseWorldPosition()
            )
        );
    }

    /// <summary>
    /// Mouse up handler.
    /// </summary>
    void OnMouseUp()
    {
        MouseUpEvent.Invoke(
            new MouseEventParams(
                gameObject,
                GetMouseWorldPosition()
            )
        );
    }

    /// <summary>
    /// Gets the world position of the mouse cursor.
    /// </summary>
    /// <returns>The world position of the mouse cursor.</returns>
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _screenZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
