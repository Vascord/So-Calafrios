using UnityEngine;

/// <summary>
/// Class which manages the movement of the player and his effects.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public CharacterController controller = default;
    [SerializeField] public float speed = 12f;
    private bool velocity = true;
    private float x;
    private float z;
    private float y;
    private Rigidbody rb;

     private void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // rb.useGravity = true;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Get the input for the movement.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Update player position with the movement input.
        Vector3 move = (transform.right * x) + (transform.forward * z) + 
            (transform.up * y);
        controller.Move(move * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
}
