using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRoulette : MonoBehaviour
{
    [SerializeField] private RectTransform leftBoundary;
    [SerializeField] private RectTransform rightBoundary;
    [SerializeField] private GameObject levelThumbnail;
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeToStop = 5;

    [SerializeField] private bool startStopping = false;
    private float stopTimer = 0;
    private Vector3 centerPosition;
    private readonly List<GameObject> levelThumbnails = new List<GameObject>();

    private void SpawnThumbnail()
    {
        GameObject newThumbnail = Instantiate(levelThumbnail, leftBoundary.transform.position, Quaternion.identity);
        newThumbnail.transform.parent = transform;
        levelThumbnails.Add(newThumbnail);
    }

    private void Start()
    {
        centerPosition = (leftBoundary.position + rightBoundary.position) / 2;
        SpawnThumbnail();
    }

    private void Update()
    {
        stopTimer += Time.deltaTime;
        foreach (GameObject thumbnail in levelThumbnails)
        {
            thumbnail.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            if (thumbnail.transform.position.x >= rightBoundary.position.x)
            {
                thumbnail.transform.position = leftBoundary.position;
            }
            //thumbnail.transform.position = Vector3.Lerp(thumbnail.transform.position, centerPosition, stopTimer / timeToStop);

            if (startStopping)
            {
                float xDistance = centerPosition.x - thumbnail.transform.position.x;
                speed = Mathf.Lerp(speed, 0, 1 - xDistance);
            }
        }
    }
}
