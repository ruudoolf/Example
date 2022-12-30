using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float maxDistance = 15;
    [SerializeField] private GameObject hittingEffect;
    private Rigidbody targetRigidbody;
    private Vector3 direction = Vector3.right ;
    private Vector3 startPosition;
    private bool hasBeenHit = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetRigidbody = GetComponent<Rigidbody>();
        Invoke(nameof(ChangeDirection), Random.Range(1f, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenHit) TargetMovment();
 
    }
    private void OnCollisionEnter(Collision collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Projectile"))
        {

            if(!hasBeenHit)TargetSpawner.Instance.Spawn();
            Instantiate(hittingEffect, collidedObject.GetContact(0).point, transform.rotation);
            hasBeenHit = true;
            targetRigidbody.useGravity = true;
            targetRigidbody.AddForce(new Vector3(0, 5, 0));
            Destroy(gameObject, 5);
        }
    }
    private void TargetMovment()
    {
        targetRigidbody.velocity = direction*2;
        if (transform.position.x >= startPosition.x+maxDistance && targetRigidbody.velocity.x >= 0)
        {
            ChangeDirection();
        }
        else if(transform.position.x <= startPosition.x-maxDistance && targetRigidbody.velocity.x <= 0)
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        direction *= -1 ;
    }
}
