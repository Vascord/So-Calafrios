using UnityEngine;
using TMPro;

public class ThrowEMP : MonoBehaviour
{
    public int empNumber;
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private TextMeshProUGUI empNumberText;
    [SerializeField] private int forceMultiplier;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        UpdateText();
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
        empNumberText.text = $"EMPs:{empNumber}";
    }
}
