using UnityEngine;

/// <summary>
/// Class that permits the movement of the camera to be locked to the mouse
/// movement.
/// </summary>
public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = default;
    [SerializeField] private Transform playerBody = default;
    // [SerializeField] private Slider slider = default;
    private float xRotation = 0f;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Lock cursor in game window (press ESC to see cursor).
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Gets X and Y angle axis.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *
            Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity *
            Time.deltaTime;

        /* Rotates player vision in Y axis and limits the rotation in 80 and 
        -80 degrees. */
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotates player body with the X camera axis.
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // This code for mouse sensibility option for later on development

    // /// <summary>
    // /// Public method which puts the slider value as the mouse sensibility.
    // /// </summary>
    // public void MouseSensibility()
    // {
    //     mouseSensitivity = slider.value;
    // }
}
