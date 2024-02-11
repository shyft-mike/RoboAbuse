using UnityEngine;

/// <summary>
/// A simple component for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// The move speed.
    /// </summary>
    public float MoveSpeed = 5.0f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            direction.y += -1;
        }

        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}
