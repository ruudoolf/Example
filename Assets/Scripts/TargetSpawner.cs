using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour

{
    [SerializeField] private Transform topRightBoundary;
    [SerializeField] private Transform bottomLeftBoundary;

    public static TargetSpawner Instance { get; set; }
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Awake()
    {   
        Instance = this;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        float x = Random.Range(bottomLeftBoundary.position.x, topRightBoundary.position.x);
        float y = Random.Range(bottomLeftBoundary.position.y, topRightBoundary.position.y);
        float z = Random.Range(bottomLeftBoundary.position.z, topRightBoundary.position.z);
        Instantiate(target, new Vector3(x,y,z), topRightBoundary.transform.rotation);
    }
}
