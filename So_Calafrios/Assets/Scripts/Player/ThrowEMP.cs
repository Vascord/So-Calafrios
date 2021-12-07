using UnityEngine;
using TMPro;

public class ThrowEMP : MonoBehaviour
{
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private TextMeshProUGUI empNumberText;
    [SerializeField] private int empNumber;

    void Start()
    {
        empNumberText.text = empNumber.ToString();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("ThrowEMP") && empNumber != 0)
        {
            ThrowGrenade();
            empNumber--;
            empNumberText.text = empNumber.ToString();
        }
    }

    void ThrowGrenade()
    {
        GameObject emp = Instantiate(empGrenade, mainCamera.transform.position, transform.rotation);
        Rigidbody rb = emp.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1500);
    }
}
