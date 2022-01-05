using UnityEngine;

/// <summary>
/// Class that permits the movement of the camera to be locked to the mouse
/// movement.
/// </summary>
public class MouseLook : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput = default;
    [SerializeField] private Transform playerBody = default;
    [SerializeField] private Transform playerHead = default;
    [SerializeField] private float mouseSensitivity = default;
    [SerializeField] private float minClamp = default;
    [SerializeField] private float maxClamp = default;
    // [SerializeField] private Slider slider = default;
    private float yRotation = 0f;
    private float xRotation = 0f;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Lock cursor in game window.
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Gets X and Y angle axis.
        float mouseY = playerInput.mouseY * mouseSensitivity * Time.deltaTime;
        float mouseX = playerInput.mouseX * mouseSensitivity * Time.deltaTime;

        /* Rotates player vision in Y axis and limits the rotation in minClamp 
        and maxClamp degrees. */
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, minClamp, maxClamp);
        xRotation += mouseX;
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);

        // Rotates player body with the X camera axis.
        playerBody.localRotation = Quaternion.Euler(0, xRotation,0);
    }

    private void LateUpdate()
    {
        transform.position = playerHead.position;
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
