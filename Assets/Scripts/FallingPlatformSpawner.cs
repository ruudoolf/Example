using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float DistanceBetweenPlatforms = 5;
    [SerializeField] private Vector2Int GridSize = new Vector2Int(5,5);
    private bool[,] IsPlatformStable;

    private void Start()
    {
        DesignGrid();
        SpawnGrid();
    }


    private void DesignGrid()
    {
        IsPlatformStable = new bool[GridSize.x, GridSize.y];
        int randomX = Random.Range(0, IsPlatformStable.GetLength(0));

        for (int y = 0; y < IsPlatformStable.GetLength(1); y++)
        {
            IsPlatformStable[randomX, y] = true;
            bool isOnRightBorder = randomX >= IsPlatformStable.GetLength(0) - 1;
            bool isOnLeftBorder = randomX <= 0;

            if (isOnRightBorder)
            {
                // Only left or straight is allowed.
                randomX += Random.Range(-1, 1);
            }
            else if (isOnLeftBorder)
            {
                // Only right or straight is allowed.
                randomX += Random.Range(0, 2);
            }
            else
            {
                randomX += Random.Range(-1, 2);
            }
        }
    }

    private void SpawnGrid()
    {
        for (int i = 0; i < IsPlatformStable.GetLength(0); i++)
        {
            for (int j = 0; j < IsPlatformStable.GetLength(1); j++)
            {
                print("Index:" + i + "," + j + "=" + IsPlatformStable[i, j]);
                if (IsPlatformStable[i, j])
                {
                    Instantiate(Platform, new Vector3(DistanceBetweenPlatforms * i, 0, DistanceBetweenPlatforms * j), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

}
