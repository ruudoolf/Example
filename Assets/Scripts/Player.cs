using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    public void Move(float xInput, float zInput)
    {
        rb.velocity = new Vector3(xInput*speed, rb.velocity.y, zInput*speed);

    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * 500);
        }
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
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, 0.5f))
        {
            isGrounded = true;
            print("Found an object - distance: " + hit.distance + " " + hit.transform.name);
        }
        else
        { 
            isGrounded = false;
        }
        
        
        Debug.DrawRay(groundCheck.position,Vector3.down*0.5f, Color.green);
        
    }

}
