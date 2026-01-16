using UnityEngine;

/// <summary>
/// First-person player controller with mouse look and WASD movement.
/// Requires a CharacterController component on the same GameObject.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float gravity = -20f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private Transform cameraTransform;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; 
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // Reset downward velocity when grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        // Mouse look - horizontal rotates the player body
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        // Mouse look - vertical rotates the camera (clamped to prevent flipping)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // WASD movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        
        // Move the player
        controller.Move((move * speed + velocity) * Time.deltaTime);
    }
}
