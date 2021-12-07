using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animationObject;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(animationObject.GetBool("Activate"))
            {
                animationObject.SetBool("Activate", false);
            }
            else
            {
                animationObject.SetBool("Activate", true);
            }
            Destroy(gameObject);
        }
    }
}
