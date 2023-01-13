using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageRoulette : MonoBehaviour
{
    [SerializeField] private RectTransform leftBoundary;
    [SerializeField] private RectTransform rightBoundary;
    [SerializeField] private GameObject levelThumbnail;
    [SerializeField] private float startSpeed = 10;
    [SerializeField] private float timeToStop = 5;
    [SerializeField] private Sprite [] levelSprites;
    

    private float currentSpeed;
    private float roundsUntilStop = 3;
    private readonly List<KeyValuePair<GameObject, bool>> levelThumbnails = new List<KeyValuePair<GameObject, bool>>();
    private int winningNumber = 1;

    private void SpawnThumbnail(int thumbnail)
    {
        Vector3 distance = (rightBoundary.position - leftBoundary.position)/levelSprites.Length*thumbnail;
        GameObject newThumbnail = Instantiate(levelThumbnail, leftBoundary.transform.position+distance, Quaternion.identity);
        newThumbnail.GetComponent<Image>().sprite = levelSprites[thumbnail];
        KeyValuePair<GameObject, bool> thumbnailWithWin = new KeyValuePair<GameObject, bool>(newThumbnail, thumbnail == winningNumber);
        newThumbnail.transform.SetParent(transform);
        levelThumbnails.Add(thumbnailWithWin);
    }

    private void Start()
    {
        currentSpeed = startSpeed;
        SpawnThumbnail(0);
        SpawnThumbnail(1);
        SpawnThumbnail(2);
    }

    private void Update()
    {
        foreach (KeyValuePair<GameObject, bool> thumbnail in levelThumbnails)
        {
            thumbnail.Key.transform.Translate(new Vector3(currentSpeed, 0, 0) * Time.deltaTime);
            if (thumbnail.Key.transform.position.x >= rightBoundary.position.x)
            {
                if (thumbnail.Value)
                {
                    roundsUntilStop--;
                }
                thumbnail.Key.transform.position = leftBoundary.position;
            }
            if (thumbnail.Value)
            {
                if (roundsUntilStop > 0)
                {
                    float xDistance = rightBoundary.position.x - thumbnail.Key.transform.position.x;
                    print(xDistance);
                    print(startSpeed + " || " + (startSpeed - startSpeed / roundsUntilStop));
                    currentSpeed = Mathf.Lerp(startSpeed, startSpeed - startSpeed / roundsUntilStop, 1f - xDistance);
                }
                else
                {
                    Vector3 centerPosition = (leftBoundary.position + rightBoundary.position) / 2;
                    float xDistance = centerPosition.x - thumbnail.Key.transform.position.x;
                    currentSpeed = Mathf.Lerp(startSpeed, 0, 1 - xDistance);
                }
            }
           
        }
    }
}
