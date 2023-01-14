using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageRoulette : MonoBehaviour
{
    [SerializeField] private RectTransform leftBoundary;
    [SerializeField] private RectTransform rightBoundary;
    [SerializeField] private GameObject levelThumbnail;
    [SerializeField] private float startSpeed = 10;
    [SerializeField] private float timeToStop = 5;
    [SerializeField] private Sprite [] levelSprites;
    [SerializeField] private int roundsUntilStop;


    private Vector3 distanceToTravel;

    private float currentSpeed;
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
        Vector3 oneWayDistance = rightBoundary.position - leftBoundary.position;
        distanceToTravel = oneWayDistance * roundsUntilStop + oneWayDistance * 0.5f;
        currentSpeed = startSpeed;
        SpawnThumbnail(0);
        SpawnThumbnail(1);
        SpawnThumbnail(2);
    }

    private void Update()
    {
        // TODO DANI: Remove this when finished testing.
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        currentSpeed = Mathf.Lerp(startSpeed, 0, Time.time / timeToStop);
        foreach (KeyValuePair<GameObject, bool> thumbnail in levelThumbnails)
        {
            thumbnail.Key.transform.Translate(new Vector3(currentSpeed, 0, 0) * Time.deltaTime);
            if (thumbnail.Key.transform.position.x >= rightBoundary.position.x)
            {
                thumbnail.Key.transform.position = leftBoundary.position;
            }
        }
    }
}
