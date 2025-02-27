using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float DistanceBetweenPlatforms = 5;
    [SerializeField] private Vector2Int GridSize = new Vector2Int(5, 5);
    [SerializeField] private int maxStepsSidewards = 3;
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
            if (Random.Range(0f, 1f) < 0.25f) xPos=TryStepSideward(xPos, yPos);
            xPos = StepForward(xPos);
        }
    }
    private int TryStepSideward(int x, int y)
    {
        
        bool canGoLeft = MaxLeftStepsSidewards(x)>0 && !DidIComeFromTheLeft(x, y);

        bool canGoRight = MaxRightStepsSidewards(x) > 0 && !DidIComeFromTheRight(x, y);

        int steps = 0;
        int direction = 0;
       
        if (canGoLeft && Random.Range(0f, 1f) < 0.5f) 
        { 
            steps = Mathf.Min(MaxLeftStepsSidewards(x), maxStepsSidewards);
            direction = -1;
        }
        else if (canGoRight)
        {
            steps = Mathf.Min(MaxRightStepsSidewards(x), maxStepsSidewards);
            direction= 1;
        }
        else if (canGoLeft)
        {
            steps = Mathf.Min(MaxLeftStepsSidewards(x), maxStepsSidewards);
            direction = -1;
        }
        for (int i = 0; i < steps; i++)
        {
            x +=direction;
            platformGrid[x, y] = true;

        }
        return x;

    }

    private int MaxRightStepsSidewards(int x)
    {
        return platformGrid.GetLength(0) - x -1;
    }

    private int MaxLeftStepsSidewards(int x)
    {
        return x;
    }

    private bool DidIComeFromTheLeft(int x, int y)
    {
        return platformGrid[x-1, y];
    }
    private bool DidIComeFromTheRight(int x, int y)
    {
        return platformGrid[x + 1, y];
    }

    private int StepForward(int xPos)
    {
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

        return xPos;
    }

    private void SpawnGrid()
    {
        GameObject platforms = new GameObject("Platforms");
        for (int i = 0; i < platformGrid.GetLength(0); i++)
        {
            for (int j = 0; j < platformGrid.GetLength(1); j++)
            {
                GameObject instance = Instantiate(Platform, new Vector3(DistanceBetweenPlatforms * i, 0, DistanceBetweenPlatforms * j), Quaternion.identity);
                instance.transform.parent = platforms.transform;
                if (!platformGrid[i, j])
                {
                    instance.GetComponent<FallingPlatform>().CanFall = true;
                }
            }
        }
    }
}
