using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float travelDistance = 3;
    [SerializeField] private Vector3 speed = Vector3.right;
    private Vector3 startPos;
    private bool movingInMainDirection = true;

    public void CollisionEvent(Collision collision)
    {
        collision.transform.parent = transform;
    }

    public void CollisionExitEvent(Collision collision)
    {
        collision.transform.parent = null;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((transform.position - startPos).magnitude > travelDistance)
        {
            movingInMainDirection = !movingInMainDirection;
        }

        if (movingInMainDirection)
        {
            transform.Translate(Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Time.deltaTime * -speed);
        }
    }
}
