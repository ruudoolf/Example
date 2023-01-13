using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageRoulette : MonoBehaviour
{
    [SerializeField] private RectTransform leftBoundary;
    [SerializeField] private RectTransform rightBoundary;
    [SerializeField] private GameObject levelThumbnail;
    [SerializeField] private float startSpeed = 10;
    [SerializeField] private float timeToStop = 5;

    private float currentSpeed;
    private float roundsUntilStop = 3;
    private readonly List<GameObject> levelThumbnails = new List<GameObject>();

    private void SpawnThumbnail()
    {
        GameObject newThumbnail = Instantiate(levelThumbnail, leftBoundary.transform.position, Quaternion.identity);
        newThumbnail.transform.SetParent(transform);
        levelThumbnails.Add(newThumbnail);
    }

    private void Start()
    {
        currentSpeed = startSpeed;
        SpawnThumbnail();
    }

    private void Update()
    {
        foreach (GameObject thumbnail in levelThumbnails)
        {
            thumbnail.transform.Translate(new Vector3(currentSpeed, 0, 0) * Time.deltaTime);

            if (thumbnail.transform.position.x >= rightBoundary.position.x)
            {
                roundsUntilStop--;
                thumbnail.transform.position = leftBoundary.position;
            }

            if (roundsUntilStop > 0)
            {
                float xDistance = rightBoundary.position.x - thumbnail.transform.position.x;
                print(xDistance);
                print(startSpeed + " || " + (startSpeed - startSpeed / roundsUntilStop));
                currentSpeed = Mathf.Lerp(startSpeed, startSpeed - startSpeed / roundsUntilStop, 1f - xDistance);
            }
            else
            {
                Vector3 centerPosition = (leftBoundary.position + rightBoundary.position) / 2;
                float xDistance = centerPosition.x - thumbnail.transform.position.x;
                currentSpeed = Mathf.Lerp(startSpeed, 0, 1 - xDistance);
            }
        }
    }
}
