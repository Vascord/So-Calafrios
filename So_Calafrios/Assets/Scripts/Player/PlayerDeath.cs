using UnityEngine;

/// <summary>
/// Class which does the fade out when the game object is started.
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    public bool invincible;
    [SerializeField] private Animator deathScene;
    [SerializeField] private PlayerInput player;

    /// <summary>
    /// Public method called when the player dies (touched by an enemy).
    /// </summary>
    public void Death()
    {
        if(!invincible)
        {
            player.enabled = false;
            deathScene.SetTrigger("Dead");
        }
    }
}
