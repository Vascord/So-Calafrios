using UnityEngine;

public abstract class State : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract State RunCurrentState();
}
