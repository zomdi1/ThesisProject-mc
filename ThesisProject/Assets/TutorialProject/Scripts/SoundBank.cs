using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    // Start is called before the first frame update

    public static SoundBank instance { get; private set; }
    public AudioClip stepAudio;
    public AudioClip stayAudio1;
    public AudioClip stayAudio2;
    public AudioClip stayAudio3;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else 
        { 
            instance = this;
        }
    }
}
