using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRoulette : MonoBehaviour
{
    [SerializeField] private RectTransform leftBoundary;
    [SerializeField] private RectTransform rightBoundary;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //leftBoundary.position += new Vector3(10,0,0)*Time.deltaTime;
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        if(transform.position.x >= rightBoundary.position.x)
        {
            transform.position = leftBoundary.position;
        }
            
     }
}
