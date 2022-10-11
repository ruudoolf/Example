using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingShape : MonoBehaviour
{
    private DanceType danceType;
    // Start is called before the first frame update
    void Start()
    {
        RandomEnum();
        
        InvokeRepeating(nameof(RandomEnum), 0, 1);
    }

    private void RandomEnum()
    {
        danceType = (DanceType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(DanceType)).Length);
        print(danceType);
    }

    // Update is called once per frame
    void Update()
    {
        switch (danceType)
        {
            case DanceType.Color:
                GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
                break;
            case DanceType.Spin:
                transform.Rotate(Vector3.one);
                break;
            case DanceType.Grow:
                transform.localScale = transform.localScale + Vector3.one * 1.5f*Time.deltaTime;
                break;
        }
    }
}