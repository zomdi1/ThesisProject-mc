using UnityEngine;

public class F_SoundManager : MonoBehaviour
{
    public static F_SoundManager instance;
 
    //Sound files
    public AudioClip stepAudio;

    private void Awake()
    {
        if (instance != null) //singleton
        {
            Debug.LogError("Found more than one Sound Manager in the scene.");
        }
        instance = this;
    }
    public void PlayFromSource(AudioSource source)
    {
        source.Play();
    }
    public void StopPlayingFromSource(AudioSource source)
    {
        source.Stop();
    }
    public void PlayAudioClipOnLoop(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.loop = true;

        PlayFromSource(source);
    }
}
