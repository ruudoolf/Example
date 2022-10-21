using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
    
{
    public bool CanFall {get; set;}
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.GetComponent<BasicBehaviour>() != null)
        {

            if (CanFall)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(0,-20,0);
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                Destroy(gameObject, 3.1f);
            }
            else
            {
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                Invoke(nameof(ResetColor), 5f);
            }
        }
    }
    private void ResetColor()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
    }
}


public class ReportCollision : MonoBehaviour
{
    private MovingPlatform movingPlatform;

    // Start is called before the first frame update
    private void Awake()
    {
        movingPlatform = transform.parent.GetComponent<MovingPlatform>();
        if (movingPlatform == null)
        {
            Debug.LogWarning("Warning, didn't detect Moving Platform on parent object of: " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        movingPlatform.CollisionEvent(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        movingPlatform.CollisionExitEvent(collision);
    }
}
