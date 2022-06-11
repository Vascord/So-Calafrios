using UnityEngine;
using TMPro;

/// <summary>
/// Class which cleans the Text after some time.
/// </summary>
public class CleanAfterTime : MonoBehaviour
{
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    private float period, timeClean;
    private TextMeshProUGUI textInBox;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        textInBox = gameObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(textInBox.text != "")
        {
            // After the time passes, the text will be erased from the text box.
            if (period > refreshTime)
            {
                timeClean++;
                if(timeClean == maxTime)
                {
                    textInBox.text = "";
                    timeClean = 0;
                }
                period = 0;
            }

            period += Time.deltaTime;
        }
    }
}
