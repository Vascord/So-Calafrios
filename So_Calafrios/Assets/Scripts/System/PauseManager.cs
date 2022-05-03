using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public delegate void PauseFunction(bool isPaused);
    private static PauseManager instance;
    private bool pause;
    private event PauseFunction onPause;

    void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void TogglePause()
    {
        //Pause
        pause = !pause;

        if (onPause != null)
        {
            onPause(pause);
        }
    }

    public static void Register(PauseFunction pauseDelegate)
    {
        instance._Register(pauseDelegate);
    }

    private void _Register(PauseFunction pauseDelegate)
    {
        onPause += pauseDelegate;
    }

    public static void Unregister(PauseFunction pauseDelegate)
    {
        instance._Unregister(pauseDelegate);
    }

    private void _Unregister(PauseFunction pauseDelegate)
    {
        onPause -= pauseDelegate;
    }
}
