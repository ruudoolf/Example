using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    private int skinIndex;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBodypart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) Next();
        if (Input.GetKeyDown(KeyCode.I)) Previous();
    }
    public void Next()
    {
        transform.GetChild(skinIndex).gameObject.SetActive(false);
        if (skinIndex < transform.childCount-1) skinIndex++;
        else skinIndex = 0;
        transform.GetChild(skinIndex).gameObject.SetActive(true);
    }
    public void Previous()
    {
        transform.GetChild(skinIndex).gameObject.SetActive(false);
        if (skinIndex > 0) skinIndex--;
        else skinIndex = transform.childCount - 1;
        transform.GetChild(skinIndex).gameObject.SetActive(true);
    }
    private void CurrentBodypart()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                skinIndex = i;
                print(skinIndex);
            }
        }
    }
}
