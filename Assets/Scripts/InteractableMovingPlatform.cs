using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMovingPlatform : MonoBehaviour, Interactable
{
    public void Interact()
    {
        GetComponent<MeshRenderer>().material.color = new Color32(randomColor(), randomColor(), randomColor(), 255);
        print("hallo");
    }
    private byte randomColor()
    {
        return (byte) Random.Range (0, 256);
    }
}
    