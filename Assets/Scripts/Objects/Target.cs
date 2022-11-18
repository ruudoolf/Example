using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigidbody;
    private Vector3 direction = Vector3.right ;
    private Vector3 startPosition;
    [SerializeField] private float maxDistance = 15;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        startPosition = transform.position;
        targetRigidbody = GetComponent<Rigidbody>();
        Invoke(nameof(ChangeDirection), Random.Range(1f, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        TargetMovment();
        if (transform.position.x >= startPosition.x+maxDistance && targetRigidbody.velocity.x >= 0)
        {
            ChangeDirection();
        }
        else if(transform.position.x <= startPosition.x-maxDistance && targetRigidbody.velocity.x <= 0)
        {
            ChangeDirection();
        }
    }
    private void OnCollisionEnter(Collision collidedObject)
    {
        if (collidedObject.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
    private void TargetMovment()
    {
        targetRigidbody.velocity = direction*2;
        
    }
    private void ChangeDirection()
    {
        CancelInvoke(nameof(ChangeDirection));
        direction = direction*-1 ;
        Invoke(nameof(ChangeDirection), Random.Range(1f, 3f));
    }
}
