using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
  
    [SerializeField]
    private bool mute = false;

    [SerializeField]
    private Sound[] music;

    [SerializeField]
    private Sound[] soundEffects;

    private readonly Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    public void Play(string name)
    {
        Sound s = SearchSound(name);
        if (s is null)
        {
            Debug.LogWarning("Sound: " + name + " notfound!");
        }
        else
        {
            if (s.interruptable || !s.Source.isPlaying)
            {
                s.Source.Play();
            }
        }
    }

    public AudioSource GetAudioSource(string name)
    {
        return audioSources[name];
    }

    private void SetUpSounds()
    {
        Sound[] musicAndSoundEffects = music.Concat(soundEffects).ToArray();

        foreach (Sound s in musicAndSoundEffects)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.clip;

            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;

            if (mute)
            {
                s.Source.mute = true;
            }

            audioSources.Add(s.name, s.Source);
        }
    }

    private Sound SearchSound(string name)
    {
        // Search music library
        Sound s = System.Array.Find(music, sound => sound.name == name);
        if (s is null)
        {
            // Search sound effects library
            s = System.Array.Find(soundEffects, sound => sound.name == name);
        }

        // Returns null if sound was not found in music or sound effects
        return s;
    }

    // TODO DANIEL: Review
    //private void PlayMusicInEndlessLoop()
    //{
    //    // Reset index to 0 if it doesn't exist or exceeds the amount of songs
    //    if (database.GetSongToPlayIndex() < 0 || database.GetSongToPlayIndex() >= music.Length)
    //    {
    //        database.SaveSongToPlayIndex(0);
    //    }
    //    PlaySong();
    //}

    // TODO DANIEL: Review
    //private void PlaySong()
    //{
    //    // Play song
    //    Sound currentSong = music[database.GetSongToPlayIndex()];
    //    currentSong.Source.Play();
    //    Debug.Log("Next Song: #" + database.GetSongToPlayIndex() + " " + currentSong.name);

    //    // Prepare for next play through
    //    database.SaveSongToPlayIndex(ComputeNextSongIndex());
    //    Invoke("PlaySong", currentSong.clip.length);
    //}

    // 
    //private int ComputeNextSongIndex()
    //{
    //    if (database.GetSongToPlayIndex() >= music.Length)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return database.GetSongToPlayIndex() + 1;
    //    }
    //}

    private void Awake()
    {
        Instance = this;
        //database = FindObjectOfType<PlayerPrefDatabase>();
        SetUpSounds();
        //PlayMusicInEndlessLoop();
    }
}