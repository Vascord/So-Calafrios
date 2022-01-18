using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public bool invincible;
    [SerializeField] private Animator deathScene;
    [SerializeField] private PlayerInput player;

    public void Death()
    {
        if(!invincible)
        {
            player.enabled = false;
            deathScene.SetTrigger("Dead");
        }
    }
}
