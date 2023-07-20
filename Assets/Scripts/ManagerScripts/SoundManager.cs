using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public bool isMute;




    void Awake()
    {
        instance = this;
    }



    public void PlayPop()
    {
        if (!isMute)
            audioSource.Play();

    }

}
