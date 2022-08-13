using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public void Move(float xInput, float zInput)
    {
        rb.velocity = new Vector3(xInput, rb.velocity.y, zInput);

    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 500);
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Interactable interactableObject = collision.gameObject.GetComponent<Interactable>();
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }
}
