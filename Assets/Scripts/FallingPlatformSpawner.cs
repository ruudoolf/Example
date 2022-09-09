using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float DistanceBetweenPlatforms = 5;
    private bool[,] IsPlatformStable = new bool [5,5];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < IsPlatformStable.GetLength(0); i++)
        {
            for (int j = 0; j < IsPlatformStable.GetLength(1); j++)
            {
                float randomNumber = Random.Range(0, 1f);
                if (randomNumber < 0.5f)
                { 
                    IsPlatformStable[i, j] = true; 
                }
                
            }
        }
        for (int i = 0; i < IsPlatformStable.GetLength(0); i++)
        {
            for (int j = 0; j < IsPlatformStable.GetLength(1); j++)
            {
                print("Index:"+ i + "," + j +"=" + IsPlatformStable[i, j]);
                if (IsPlatformStable[i, j])
                {
                    Instantiate(Platform, new Vector3(DistanceBetweenPlatforms*i, 0, DistanceBetweenPlatforms * j), Quaternion.identity);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
