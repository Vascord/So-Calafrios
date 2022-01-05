using UnityEngine;
using TMPro;

public class ThrowEMP : MonoBehaviour
{
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private TextMeshProUGUI empNumberText;
    [SerializeField] private int empNumber;
    [SerializeField] private int forceMultiplier;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        empNumberText.text = $"EMPs:{empNumber}";
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
            empNumberText.text = $"EMPs:{empNumber}";
        }
    }
}
