using UnityEngine;

/// <summary>
/// Class which manages the cheats of the player.
/// </summary>
public class PlayerCheats : MonoBehaviour
{
    [SerializeField] private GameObject cheatText;
    [SerializeField] private GameObject invincibleText;
    [SerializeField] private Vector3 begining = default;
    [SerializeField] private Vector3 afterGate = default;
    [SerializeField] private ThrowEMP eMPGrenades = default;
    [SerializeField] private CharacterController character = default;
    [SerializeField] private PlayerDeath playerDeath;

    /// <summary>
    /// Public method called when the player presses a cheat button.
    /// </summary>
    /// <param name="cheatNumber"> Number that determines which cheat
    /// will be used.</param>
    public void Cheats(int cheatNumber)
    {
        // TP to begining cheat
        switch(cheatNumber) 
        {
            case 0:
                cheatText.SetActive(cheatText.activeSelf);
                break;
            case 1:
                character.enabled = false;
                gameObject.transform.position = begining;
                character.enabled = true;
                break;
            case 2:
                character.enabled = false;
                gameObject.transform.position = afterGate;
                character.enabled = true;
                break;
            case 3:
                playerDeath.invincible = !playerDeath.invincible;
                invincibleText.SetActive(!invincibleText.activeSelf);
                break;
            case 4:
                eMPGrenades.empNumber++;
                eMPGrenades.UpdateText();
                break;
        }
    }
}
