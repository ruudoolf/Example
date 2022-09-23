using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float DistanceBetweenPlatforms = 5;
    [SerializeField] private Vector2Int GridSize = new Vector2Int(5,5);
    private bool[,] platformGrid;

    private void Start()
    {
        DesignGrid();
        SpawnGrid();
    }

    private void DesignGrid()
    {
        platformGrid = new bool[GridSize.x, GridSize.y];
        int xPos = Random.Range(0, platformGrid.GetLength(0));

        for (int yPos = 0; yPos < platformGrid.GetLength(1); yPos++)
        {
            platformGrid[xPos, yPos] = true;

            bool isOnRightBorder = xPos >= platformGrid.GetLength(0) - 1;
            bool isOnLeftBorder = xPos <= 0;

            if (isOnRightBorder)
            {
                // Only left or straight is allowed.
                xPos += Random.Range(-1, 1);
            }
            else if (isOnLeftBorder)
            {
                // Only right or straight is allowed.
                xPos += Random.Range(0, 2);
            }
            else
            {
                xPos += Random.Range(-1, 2);
            }
        }
    }


    private void SpawnGrid()
    {
        for (int i = 0; i < platformGrid.GetLength(0); i++)
        {
            for (int j = 0; j < platformGrid.GetLength(1); j++)
            {
                if (platformGrid[i, j])
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
