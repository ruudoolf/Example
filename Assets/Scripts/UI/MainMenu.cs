using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject buttonMenu;
    [SerializeField] private Image imageFade;
    public void StartGame()
    {
        print(SceneManager.sceneCountInBuildSettings);
        //buttonMenu.SetActive(false);
        //Color tempColor = imageFade.color;
        //tempColor.a = 1f;
        //imageFade.color = tempColor;
        SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
