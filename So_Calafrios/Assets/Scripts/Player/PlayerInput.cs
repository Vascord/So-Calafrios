using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject pause = default;
    public float mouseX { get; private set;}
    public float mouseY { get; private set;}
    public float movementX { get; private set;}
    public float movementZ { get; private set;}
    private PlayerMovement movement;
    private Flashlight flashlight;
    private ThrowEMP eMP;
    private Headset headset;
    private PlayerInteraction interaction;
    private PauseMenu pauseMenu;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
        flashlight = gameObject.GetComponent<Flashlight>();
        eMP = gameObject.GetComponent<ThrowEMP>();
        headset = gameObject.GetComponent<Headset>();
        interaction = gameObject.GetComponent<PlayerInteraction>();
        pauseMenu = pause.GetComponent<PauseMenu>();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
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
            movement.Walk(
                Input.GetButton("Run"), Input.GetButtonUp("Run"));
        }
        else
        {
            movement.Stop();
        }

        // Input for light.
        if(Input.GetButtonDown("LightToggle"))
        {
            flashlight.ToggleLight();
        }

        // Input for EMP.
        if(Input.GetButtonDown("ThrowEMP"))
        {
            eMP.ThrowGrenade();
        }

        // Input for headset.
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            headset.HeadsetToggle();
        }

        // Interraction Input
        if(Input.GetMouseButtonDown(0))
        {
            interaction.CheckForInteraction();
        }

        // Pause Button
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.PauseKey();
        }
    }
}
