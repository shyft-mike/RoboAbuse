using UnityEngine;

/// <summary>
/// A simple component for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// The move speed.
    /// </summary>
    public float MoveSpeed = 10.0f;

    /// <summary>
    /// The rotation speed;
    /// </summary>
    public float RotateSpeed = 30.0f;

    void Start()
    {

    }

    void Update()
    {
        // Translation
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

        // Rotation
        float yRotation = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            yRotation += -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yRotation += 1;
        }

        transform.Rotate(Vector3.up, yRotation * RotateSpeed * Time.deltaTime);
    }
}
