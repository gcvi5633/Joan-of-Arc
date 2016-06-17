using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    AudioSource musicPlayer;
    public AudioClip[] music;
    // Use this for initialization
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic(int a)
    {
        musicPlayer.clip = music[a];
        musicPlayer.Play();
    }
}