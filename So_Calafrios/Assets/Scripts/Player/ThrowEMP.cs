using UnityEngine;

public class ThrowEMP : MonoBehaviour
{
    [SerializeField] private GameObject empGrenade;
    [SerializeField] private GameObject mainCamera;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("ThrowEMP"))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject emp = Instantiate(empGrenade, mainCamera.transform.position, transform.rotation);
        Rigidbody rb = emp.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1500);
    }
}
