using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool interruptable;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public AudioSource Source { get; set; }
}
