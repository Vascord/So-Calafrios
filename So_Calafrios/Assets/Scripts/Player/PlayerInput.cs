using UnityEngine;

/// <summary>
/// Class which manages the player's inputs.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject pause = default;
    [SerializeField] private PauseManager pauseManager = default;
    [SerializeField] private bool headsetOn;
    public float mouseX { get; private set;}
    public float mouseY { get; private set;}
    public float movementX { get; private set;}
    public float movementZ { get; private set;}
    public bool inGameInputs;
    private PlayerMovement movement;
    private Flashlight flashlight;
    private ThrowEMP eMP;
    private Headset headset;
    private PlayerInteraction interaction;
    private PauseMenu pauseMenu;
    private PlayerCheats cheats;
    private bool cheatOn;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
        flashlight = gameObject.GetComponent<Flashlight>();
        eMP = gameObject.GetComponent<ThrowEMP>();
        headset = gameObject.GetComponent<Headset>();
        interaction = gameObject.GetComponent<PlayerInteraction>();
        pauseMenu = pause.GetComponent<PauseMenu>();
        cheats = gameObject.GetComponent<PlayerCheats>();
        cheatOn = false;
        inGameInputs = true;
        headsetOn = false;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(inGameInputs)
        {
            InGameInputs();
        }
        else
        {
            MenuInputs();
        }
    }

    private void InGameInputs()
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
        if(Input.GetButtonDown("HeadsetToggle") && headsetOn)
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

        // Cheats Button
        if(Input.GetButtonDown("CheatOn"))
        {
            cheatOn = !cheatOn;
            cheats.Cheats(0);
        }

        // TP to begining cheat
        if(cheatOn && Input.GetButtonDown("Cheat1"))
        {
            cheats.Cheats(1);
        }

        // TP after the gate
        if(cheatOn && Input.GetButtonDown("Cheat2"))
        {
            cheats.Cheats(2);
        }

        // Invincible cheat
        if(cheatOn && Input.GetButtonDown("Cheat3"))
        {
            cheats.Cheats(3);
        }

        // Additional EMP cheat
        if(cheatOn && Input.GetButtonDown("Cheat4"))
        {
            cheats.Cheats(4);
        }
    }

    private void MenuInputs()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.PauseKey();
        }
    }

    public void HeadsetActivate()
    {
        headsetOn = true;
    }
}
