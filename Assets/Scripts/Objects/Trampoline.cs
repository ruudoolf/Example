using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 700);
        }
        Interactable interactable = collision.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Interact(); 
        }
    }
}
