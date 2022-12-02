using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour

{
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
        Instantiate(target);
    }
}
