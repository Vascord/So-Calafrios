using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject pause = default;
    public float mouseX { get; private set;}
    public float mouseY { get; private set;}
    public float movementX { get; private set;}
    public float movementZ { get; private set;}

    // Update is called once per frame
    void Update()
    {
        // Mouse input.
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        // Movement Input
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            gameObject.GetComponent<PlayerMovement>().Walk(
                Input.GetButton("Run"), Input.GetButtonUp("Run"));
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().Stop();
        }

        // Input for light.
        if(Input.GetButtonDown("LightToggle"))
        {
            gameObject.GetComponent<Flashlight>().ToggleLight();
        }

        // Input for EMP.
        if(Input.GetButtonDown("ThrowEMP"))
        {
            gameObject.GetComponent<ThrowEMP>().ThrowGrenade();
        }

        // Input for headset.
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            gameObject.GetComponent<Headset>().HeadsetToggle();
        }

        // Interraction Input
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<PlayerInteraction>().CheckForInteraction();
        }

        // Pause Button
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.GetComponent<PauseMenu>().PauseKey();
        }
    }
}
