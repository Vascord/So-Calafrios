using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that manages the player's interactions.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private CanvasManager canvasManager = default;
    private const float MAX_INTERACTION_DISTANCE = 3f;
    private Transform _cameraTransform;
    private Interactive _currentInteractive;
    private bool _requirementsInInventory;
    private List<Interactive> _inventory;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        _cameraTransform            = GetComponentInChildren<Camera>().transform;
        _requirementsInInventory    = false;
        _inventory                  = new List<Interactive>();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
    }

    /// <summary>
    /// Private method which checks for an interactive item with a raycast.
    /// </summary>
    private void CheckForInteractive()
    {
        // If the raycast detects an object.
        if (Physics.Raycast(_cameraTransform.position,
            _cameraTransform.forward,
            out RaycastHit hitInfo,
            MAX_INTERACTION_DISTANCE))
        {
            Interactive interactive = 
                hitInfo.transform.GetComponent<Interactive>();

            // Sees if it has an interactive script.
            if (interactive == null)
                ClearCurrentInteractive();
            else if (interactive != _currentInteractive)
                SetCurrentInteractive(interactive);
        }
        // Clears the interactive text.
        else
        {
            ClearCurrentInteractive();
        }
    }

    /// <summary>
    /// Private method that sees the possible interaction with the object.
    /// </summary>
    private void SetCurrentInteractive(Interactive interactive)
    {
        _currentInteractive = interactive;

        if (PlayerHasInteractionRequirements())
        {
            // Shows the interaction text of an object which he can interact.
            _requirementsInInventory = true;
            if(interactive.GetInteractionText() != "")
            {
                canvasManager.ShowInteractionPanel(
                    interactive.GetInteractionText());
            }
        }
        else
        {
            // Shows the requirement text of the object.
            _requirementsInInventory = false;
            canvasManager.ShowInteractionPanel(interactive.requirementText);
        }
    }

    /// <summary>
    /// Private method that sees if the player has all the interaction
    /// requirements to interact with it.
    /// </summary>
    /// <returns>True if has all the requirements, false otherwise.</returns>
    private bool PlayerHasInteractionRequirements()
    {
        if (_currentInteractive.requirements == null)
            return true;

        for (int i = 0; i < _currentInteractive.requirements.Length; ++i)
        {
            if (!IsInInventory(_currentInteractive.requirements[i]))
                return false;
        }
        return true;
    }

    /// <summary>
    /// Private method that clears the interactive text.
    /// </summary>
    private void ClearCurrentInteractive()
    {
        _currentInteractive = null;
        canvasManager.HideInteractionPanel();
    }

    /// <summary>
    /// Private method that checks for the interaction with the object.
    /// </summary>
    private void CheckForInteraction()
    {
        if (Input.GetMouseButtonDown(0) && _currentInteractive != null)
        {
            // Sees if it's a pickable item.
            if (_currentInteractive.type == 
                Interactive.InteractiveType.PICKABLE)
            {
                PickCurrentInteractive();
            }
            // Sees if it's just to interact.
            else if (_requirementsInInventory)
            {
                InteractWithCurrentInteractive();
            }
        }
    }

    /// <summary>
    /// Private method to pick an object to his inventory.
    /// </summary>
    private void PickCurrentInteractive()
    {
        _currentInteractive.gameObject.SetActive(false);
        AddToInventory(_currentInteractive);
    }

    /// <summary>
    /// Private method which do the interact of the object.
    /// </summary>
    private void InteractWithCurrentInteractive()
    {
        for (int i = 0; i < _currentInteractive.requirements.Length; ++i)
        {
            Interactive currentRequirement = _currentInteractive.requirements[i];
            currentRequirement.gameObject.SetActive(true);
            currentRequirement.Interact();
            RemoveFromInventory(currentRequirement);
        }

        _currentInteractive.Interact();

        ClearCurrentInteractive();
    }

    /// <summary>
    /// Private method which adds the item to the player inventory.
    /// </summary>
    /// <param name="item">Interactive item that's going to be added to
    /// the inventory.</param>
    private void AddToInventory(Interactive item)
    {
        _inventory.Add(item);
    }

    /// <summary>
    /// Private method which removes an object used by the player.
    /// </summary>
    /// <param name="item">Interactive item that's going to be removed from
    /// the inventory.</param>
    private void RemoveFromInventory(Interactive item)
    {
        _inventory.Remove(item);
    }

    /// <summary>
    /// Private method which sees if an item is in the inventory.
    /// </summary>
    /// <param name="item">Interactive item that is needed for the
    /// requirement.</param>
    /// <returns>True if he's in the inventory, false otherwise.</returns>
    private bool IsInInventory(Interactive item)
    {
        return _inventory.Contains(item);
    }
}
