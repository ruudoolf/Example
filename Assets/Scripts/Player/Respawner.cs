using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 checkPoint;
    private float fallingTimer=3;
    private float maxFallingTime = 3;
    // Start is called before the first frame update
    private void Start()
    {
        checkPoint = transform.position;
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

        print(fallingTimer);

    }
    private void Respawn()
    {
        transform.position = checkPoint;
        ResetTimer();
    }

    private void ResetTimer()
    {
        fallingTimer = maxFallingTime;
    }
}
