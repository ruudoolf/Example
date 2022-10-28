using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3 CheckPoint {get; set;}
    private float fallingTimer=3;
    private float maxFallingTime = 3;
    // Start is called before the first frame update
    private void Start()
    {
        CheckPoint = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (!GetComponent<BasicBehaviour>().IsGrounded() && !GetComponent<FlyBehaviour>().IsFlying)
        {
            fallingTimer -= Time.deltaTime;

            if (fallingTimer <= 0)
            {
                Respawn();
            }

        }
        else
        {
            ResetTimer();
        }

    }
    private void Respawn()
    {
        transform.position = CheckPoint;
        ResetTimer();
    }

    private void ResetTimer()
    {
        fallingTimer = maxFallingTime;
    }
}
