using UnityEngine;
using TMPro;

public class CleanAfterTime : MonoBehaviour
{
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    private float period, timeDestroy;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(gameObject.GetComponent<TextMeshProUGUI>().text != "")
        {
            // This is for the battery of the flashlight.
            if (period > refreshTime)
            {
                timeDestroy++;
                if(timeDestroy == maxTime)
                {
                    gameObject.GetComponent<TextMeshProUGUI>().text = "";
                    timeDestroy = 0;
                }
                period = 0;
            }

            period += Time.deltaTime;
        }
    }
}
