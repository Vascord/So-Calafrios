using UnityEngine;

/// <summary>
/// Class which manages the movement of the player and his effects.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller = default;
    [SerializeField] private readonly float speed = 12f;
    private float x;
    private float z;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Get the input for the movement.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Private method called 60 per second.
    /// </summary>
    private void FixedUpdate()
    {
        // Update player position with the movement input.
        Vector3 move = (transform.right * x * speed) + 
            (transform.forward * z * speed) + (transform.up * -15);
        controller.Move(move * Time.deltaTime);
    }
}
