using UnityEngine;
using TMPro;

/// <summary>
/// Class which the throwing and text of the EMP.
/// </summary>
public class ThrowEMP : MonoBehaviour
{
    public int empNumber;
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private TextMeshProUGUI empNumberText;
    [SerializeField] private int forceMultiplier;
    [SerializeField] private int maxEmps;
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    private float period, timeCreate;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        UpdateText();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(empNumber < maxEmps)
        {
            // After a certain period of time, an EMP will be added to your
            // arsenal.
            if (period > refreshTime)
            {
                timeCreate++;
                if(timeCreate == maxTime)
                {
                    timeCreate = 0;
                    empNumber++;
                    UpdateText();
                }
                period = 0;
            }

            period += Time.deltaTime;
        }
    }

    /// <summary>
    /// Private method to instantiate and throw the EMP forward.
    /// </summary>
    public void ThrowGrenade()
    {
        if(empNumber != 0)
        {
            GameObject emp = Instantiate(empGrenade,
                mainCamera.transform.position, transform.rotation);
            Rigidbody rb = emp.GetComponent<Rigidbody>();
            rb.AddForce(mainCamera.transform.forward * forceMultiplier);

            empNumber--;
            UpdateText();
        }
    }

    public void UpdateText()
    {
        empNumberText.text = $"x{empNumber}";   
    }
}
