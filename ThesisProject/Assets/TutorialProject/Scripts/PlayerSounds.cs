using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource source;
    private float timer;
    private int random;

    private void Awake()
    {
        source = GetComponent<AudioSource>();   
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            if (random == 1)
            {
                source.clip = SoundBank.instance.stayAudio1;
            }
            else if (random == 2) 
            {
                source.clip = SoundBank.instance.stayAudio2;
            }
            else
            {
                source.clip = SoundBank.instance.stayAudio3;
            }

            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    private void OnMovement()
    {
        if (source.clip != SoundBank.instance.stepAudio)
        {
            source.clip = SoundBank.instance.stepAudio;
            source.loop = true;
        }

        if (!source.isPlaying)
        {
            source.Play();
        }

        timer = 0;
    }

    private void OnMovementStop()
    {
        source.Stop();
        random = Random.Range(1, 4);
    }
}
