using UnityEngine;
using TMPro;

public class ThrowEMP : MonoBehaviour
{
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private TextMeshProUGUI empNumberText;
    [SerializeField] private int empNumber;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        empNumberText.text = $"EMPs:{empNumber}";
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Sees if player wants to throw EMPs and checks if he has.
        if(Input.GetButtonDown("ThrowEMP") && empNumber != 0)
        {
            ThrowGrenade();
            empNumber--;
            empNumberText.text = $"EMPs:{empNumber}";
        }
    }

    /// <summary>
    /// Private method to instantiate and throw the EMP forward.
    /// </summary>
    private void ThrowGrenade()
    {
        GameObject emp = Instantiate(empGrenade, mainCamera.transform.position,
            transform.rotation);
        Rigidbody rb = emp.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1500);
    }
}
