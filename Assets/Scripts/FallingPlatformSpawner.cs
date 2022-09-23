using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float DistanceBetweenPlatforms = 5;
    [SerializeField] private Vector2Int GridSize = new Vector2Int(5,5);
    [SerializeField] private float goSideWaysProbability = 0.25f;
    [SerializeField] private int maxAllowedSideSteps = 3;
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
            print($"FORW STEP TO: {xPos}, {yPos}");

            // 75% chance to go sideways
            float randomPercentage = Random.Range(0f,1f);
            if (randomPercentage < goSideWaysProbability) xPos = TryStepSideways(xPos, yPos);

            xPos = StepForward(xPos);
        }
    }


    private void SpawnGrid()
    {
        for (int i = 0; i < platformGrid.GetLength(0); i++)
        {
            for (int j = 0; j < platformGrid.GetLength(1); j++)
            {
                print("Index:" + i + "," + j + "=" + platformGrid[i, j]);
                if (platformGrid[i, j])
                {
                    Instantiate(Platform, new Vector3(DistanceBetweenPlatforms * i, 0, DistanceBetweenPlatforms * j), Quaternion.identity);
                }
            }
        }
    }

    private int TryStepSideways(int xPos, int yPos)
    {
        bool canGoLeft = CountMaxLeftSteps(xPos) > 0 && !CameFromLeft(xPos, yPos);
        bool canGoRight = CountMaxRightSteps(xPos) > 0 && !CameFromRight(xPos, yPos);

        // 50/50 chance to left/right
        float randomPercentage = Random.Range(0f, 1f);

        int maxPossibleSteps = 0;
        int direction = 0;
        if (randomPercentage < 0.5f && canGoLeft)
        {
            maxPossibleSteps = CountMaxLeftSteps(xPos);
            direction = -1;
        }
        else if (canGoRight)
        {
            maxPossibleSteps = CountMaxRightSteps(xPos);
            direction = 1;
        }
        else if(canGoLeft)
        {
            maxPossibleSteps = CountMaxLeftSteps(xPos);
            direction = -1;
        }


        int actualSteps = Mathf.Min(maxPossibleSteps, maxAllowedSideSteps);
        for (int i = 0; i < actualSteps; i++)
        {
            xPos += direction;
            platformGrid[xPos, yPos] = true;
            print($"SIDE STEP TO: {xPos}, {yPos}");
        }

        return xPos;
    }

    private int StepForward(int currentPos)
    {
        bool isOnRightBorder = currentPos >= platformGrid.GetLength(0) - 1;
        bool isOnLeftBorder = currentPos <= 0;

        if (isOnRightBorder)
        {
            // Only left or straight is allowed.
            currentPos += Random.Range(-1, 1);
        }
        else if (isOnLeftBorder)
        {
            // Only right or straight is allowed.
            currentPos += Random.Range(0, 2);
        }
        else
        {
            currentPos += Random.Range(-1, 2);
        }

        return currentPos;
    }

    private int CountMaxLeftSteps(int xPos)
    {
        return xPos;
    }

    private int CountMaxRightSteps(int xPos)
    {
        return platformGrid.GetLength(0) - xPos - 1;
    }

    private bool CameFromRight(int xPosition, int yPosition)
    {
        return platformGrid[xPosition + 1, yPosition];
    }

    private bool CameFromLeft(int xPosition, int yPosition)
    {
        return platformGrid[xPosition - 1, yPosition];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
