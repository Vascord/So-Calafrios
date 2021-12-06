using UnityEngine;

/// <summary>
/// Class which manages the movement of the player and his effects.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller = default;
    [SerializeField] private float speed = 12f;
    [SerializeField] private AudioSource moveSound = default;
    [SerializeField] private Animator flashlight = default;
    private float x, z;
    private bool firstTimeStoping, firstTimeWalking;

    private void Start()
    {
        firstTimeStoping = false;
        firstTimeWalking = true;
    }
    
    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Get the input for the movement.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Conditions for walking sound.
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            // When player stops.
            if(firstTimeStoping)
            {
                // moveSound.GetComponent<AudioSource>().Stop();
                flashlight.SetBool("Walking", false);
                firstTimeStoping = false;
                firstTimeWalking = true;
            }
        }
        else
        {
            // When player is moving.
            if(firstTimeWalking)
            {
                // moveSound.GetComponent<AudioSource>().Play();
                flashlight.SetBool("Walking", true);
                firstTimeStoping = true;
                firstTimeWalking = false;
            }
        }
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
