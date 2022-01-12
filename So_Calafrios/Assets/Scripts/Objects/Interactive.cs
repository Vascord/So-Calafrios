using UnityEngine;

/// <summary>
/// Class which controls the interact between the player and the object.
/// </summary>
public class Interactive : MonoBehaviour
{
    public enum InteractiveType {
        PICKABLE,
        INTERACT_ONCE,
        INTERACT_MULTI,
        INDIRECT };
    public InteractiveType type;
    public string requirementText;
    public Interactive[] requirements;
    [SerializeField] private bool isActive = default;
    [SerializeField] private bool deactivationLeader = false;
    [SerializeField] private string[] interactionTexts = default;
    [SerializeField] private Interactive[] activationChain = default;
    [SerializeField] private Interactive[] deActivationChain = default;
    [SerializeField] private Interactive[] interactionChain = default;
    private Animator _animator;
    private int _curInteractionTextId;
    private AudioSource sound;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        _animator               = GetComponent<Animator>();
        _curInteractionTextId   = 0;
        sound                   = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if (deactivationLeader == true)
            CheckForDeactivationCicle();
    }

    /// <summary>
    /// Public method which gets the interaction text.
    /// </summary>
    /// <returns>The interaction text.</returns>
    public string GetInteractionText()
    {
        return interactionTexts[_curInteractionTextId];
    }

    /// <summary>
    /// Public method which activates the trigger "Activate" and says that the
    /// object is active.
    /// </summary>
    public void Activate()
    {
        isActive = true;

        if (_animator != null)
            Debug.Log("Lmao"); 
            _animator.SetTrigger("Activate");
    }

    /// <summary>
    /// Public method which activates the trigger "Interact" with his activate
    /// chains.
    /// </summary>
    public void Interact()
    {
        if (_animator != null)
            _animator.SetTrigger("Interact");

        // If it's not active, then there's no activation chain.
        if(!isActive)
        {
            ProcessDeactivationChain();

            if (type == InteractiveType.INTERACT_ONCE || 
                type == InteractiveType.PICKABLE)
            {
                Destroy(this);
            }
        }
        // If it is, then the chain will activate.
        if (isActive)
        {
            ProcessDeactivationChain();
            ProcessActivationChain();
            ProcessInteractionChain();

            if (type == InteractiveType.INTERACT_ONCE || 
                type == InteractiveType.PICKABLE)
            {
                Destroy(this);
            }
            else if (type == InteractiveType.INTERACT_MULTI)
            {
                _curInteractionTextId = (_curInteractionTextId + 1) %
                    interactionTexts.Length;
            }
        }
    }

    /// <summary>
    /// Private method that activates the activation chains.
    /// </summary>
    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
            {
                activationChain[i].Activate();
            }
        }
    }

    /// <summary>
    /// Private method that activate the interaction chains.
    /// </summary>
    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }

    /// <summary>
    /// Private method that desactivates the object.
    /// </summary>
    private void DeActivate()
    {
        isActive = false;
    }

    /// <summary>
    /// Private method that desactivates a chain.
    /// </summary>
    private void ProcessDeactivationChain()
    {
        if (deActivationChain != null)
        {
            for (int i = 0; i < deActivationChain.Length; ++i)
            {
                deActivationChain[i].DeActivate();
            }
        }
    }

    /// <summary>
    /// Private method that sees if there's anykind of deactivated cycles.
    /// </summary>
    private void CheckForDeactivationCicle()
    {
        if (deActivationChain != null)
        {
            for (int i = 0; i < deActivationChain.Length; ++i)
            {
                if (!deActivationChain[i].isActive)
                    continue;
                else
                    return;
            }
            Activate();
        }
    }

    /// <summary>
    /// Private method that plays the sound in the component AudioSource of
    /// the object.
    /// </summary>
    private void AudioPlay()
    {
        GetComponent<AudioSource>().Play();
    }
}