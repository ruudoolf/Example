using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private bool isKnockedOut;
    private float getUpTimer;
    [SerializeField] private float getUpDuration=1;
    public void Move(float xInput, float zInput)
    {
        if (!isKnockedOut)
        {
            rb.velocity = new Vector3(xInput * speed, rb.velocity.y, zInput * speed);
        }


    }
    private void getUp()
    {
        isKnockedOut = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX ;
        
    }
    public void Jump()
    {
        if (isGrounded && !isKnockedOut)
        {
            rb.AddForce(Vector3.up * 500);
        }
    }

    public void Knockout()
    {
        rb.constraints = RigidbodyConstraints.None;
        isKnockedOut = true;
        rb.AddForce(Vector3.left * 5);
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Knockout();
        Invoke(nameof(getUp), 2);
        
    }
    private void Update()
    {
        if (!isKnockedOut)
        {
            getUpTimer += Time.deltaTime;
            print(getUpTimer / getUpDuration);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, getUpTimer/getUpDuration);
        }
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
