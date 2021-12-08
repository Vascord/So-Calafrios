using UnityEngine;
using System.Collections;
using TMPro;

/// <summary>
/// Class which manages the movement of the player and his effects.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller = default;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float maxStamina = 10f;
    [SerializeField] private TextMeshProUGUI staminaPourcentage;
    [SerializeField] private AudioSource walkSound = default;
    [SerializeField] private AudioSource runSound = default;
    [SerializeField] private Animator flashlight = default;
    private float x, z, walkingSpeed, stamina;
    private bool firstTimeStoping, firstTimeWalking, startRun, stopRun;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        stamina = maxStamina;
        StartCoroutine(RunStamina());
        firstTimeStoping = false;
        firstTimeWalking = true;
        walkingSpeed = speed;
        startRun = false;
        stopRun = false;
    }
    
    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Get the input for the movement.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Player wants to run before moving.
        if(Input.GetButtonDown("Run"))
        {
            startRun = true;
        }
        // Player decides to not run before moving
        else if(Input.GetButtonUp("Run"))
        {
            speed = walkingSpeed;
            stopRun = true;
        }

        // Conditions for walking and run sound.

        //If not moving ...
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            // Stops walk/run sound, flashlight don't move and resets the bools.
            if(firstTimeStoping)
            {
                if(walkSound.isPlaying) {walkSound.Stop();}
                if(runSound.isPlaying) {runSound.Stop();}
                speed = walkingSpeed;
                flashlight.SetBool("Walking", false);

                firstTimeStoping = false;
                firstTimeWalking = true;
            }
        }
        //If moving ...
        else
        {
            // Starts running while moving.
            if(Input.GetButtonDown("Run"))
            {
                startRun = true;
            }
            // Stops running while moving
            else if(Input.GetButtonUp("Run") || stamina <= 0f)
            {
                speed = walkingSpeed;
                stopRun = true;
            }

            // Starts running, stopping walk sound if activated and starts run
            // sound, and flashlight movement if not activated. This is useful
            // to activate run while the player walks
            if(startRun)
            {
                if(walkSound.isPlaying) {walkSound.Stop();}
                speed = walkingSpeed * 1.5f;
                runSound.Play();
                flashlight.SetBool("Walking", true);

                startRun = false;
                firstTimeStoping = true;
                firstTimeWalking = false;
            }
            
            // Stop running, no run sound, and is ready to activate the walk. 
            // This is useful to desactivate the run then continuing walk.
            if(stopRun)
            {
                runSound.Stop();
                flashlight.SetBool("Walking", false);
                firstTimeWalking = true;
                stopRun = false;
            }

            // Starts to walk. 
            // Activates sounds and flashlight movement.
            if(firstTimeWalking)
            {
                walkSound.Play();
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

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private IEnumerator RunStamina()
    {
        // This is for the battery of the flashlight.
        for(;;)
        {
            if(speed != walkingSpeed && (Input.GetButton("Horizontal") ||
                Input.GetButton("Vertical")))
            {
                stamina -= 0.1f;
            }
            else
            {
                stamina += 0.05f;
            }

            // Minimum stamina.
            if(stamina <= 0f)
            {
                stamina = 0f;
            }
            // Maximum stamina.
            else if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }

            // Puts on the interface.
            staminaPourcentage.text = $"STM:{stamina:n1}";

            yield return new WaitForSeconds(0.1f);
        }
    }
}
