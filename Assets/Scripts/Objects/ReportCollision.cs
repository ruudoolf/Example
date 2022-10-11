using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
