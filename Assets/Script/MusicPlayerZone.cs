using UnityEngine;
using System.Collections;

public class MusicPlayerZone : MonoBehaviour
{
    public MusicPlayer musicPlayer;
    public int musicIndex_Enter;
    public int musicIndex_Exit;
    public bool PlayExitMusic;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicPlayer.PlayMusic(musicIndex_Enter);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && PlayExitMusic) 
        {

            musicPlayer.PlayMusic(musicIndex_Exit);
        }
    }
}

