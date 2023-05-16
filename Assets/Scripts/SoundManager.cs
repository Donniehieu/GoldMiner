using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicAudio;

    public AudioSource effectAudio;

    public  AudioSource effectCollision;

    public AudioSource effectTap;

    public AudioSource effectWinLose;

    public Setting setting;
    public SOAudioClip clipList;
    public bool isBlank;
    public static SoundManager Instance;
    private void Awake()
    {
        setting = FindObjectOfType<Setting>();
        clipList = Resources.Load<SOAudioClip>("Scriptable/ClipData");
        musicAudio.clip = clipList.clipLevel;
        Instance = this;
    }
    public void PlayTap()
    {
        if (setting.canPlayFxSound == false) return;
        effectTap.clip = clipList.clipTouch;
        effectTap.PlayOneShot(effectTap.clip);
    }
    public void PlaySoundFx(AudioClip clip)
    {
        if (setting.canPlayFxSound == false|| effectAudio.clip ==clip) return;
        effectAudio.clip = clip;        
        effectAudio.Play();        
    } 

    public void PlayWinLose(AudioClip clip)
    {
        effectWinLose.clip = clip;
        effectWinLose.PlayOneShot(clip);
    }

    public void PlayColliderSound(AudioClip clip)
    {
        if (setting.canPlayFxSound == false) return;
        effectCollision.clip = clip;
        effectCollision.PlayOneShot(clip);
     
    }
    public void MuteSoundFx()
    {
        effectAudio.Stop();
        effectCollision.Stop();
        
    }
    public void MuteMusic()
    {
        musicAudio.Stop();
    }
    public void PlayMusic()
    {  
        musicAudio.Play();
    }
}
