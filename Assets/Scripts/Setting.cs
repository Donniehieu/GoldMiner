using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    [SerializeField] SOItem itemData;

    [SerializeField] GameObject btnSound;

    [SerializeField] GameObject btnMusic;  

    private static string isSoundOn = "isSoundOn";

    private static string isMusicOn = "isMusicOn";

    private static string txt_timePlay = "timePlay";

    private int MusicStatus, SoundStatus;

    private int soundClick;

    private int musicClick;

    private int timePlay;

    public bool canPlayFxSound;
   

 
    private void Awake()
    {           
        if (FirstTimePlay())
        {
            SetMusicOn();
            SetSoundOn();
        }            
        itemData = Resources.Load<SOItem>("Scriptable/ItemDB");       
        ValidateMusic();
        OnValidateSound();

    }

    public bool FirstTimePlay()
    {
        timePlay = PlayerPrefs.GetInt(txt_timePlay);
        timePlay++;
        PlayerPrefs.SetInt(txt_timePlay, timePlay);
        if (timePlay == 1) return true;
        else return false;
    }

    private void SetMusicOn()
    {
        PlayerPrefs.SetInt(isMusicOn, 1);        
    }

    private void SetSoundOn()
    {
        PlayerPrefs.SetInt(isSoundOn, 1);
    }

    private void SetSoundOff()
    {
        PlayerPrefs.SetInt(isSoundOn, 0);
    }
    private void SetMusicOff()
    {
        PlayerPrefs.SetInt(isMusicOn, 0);
    }

    private void ValidateMusic()
    {
        MusicStatus = PlayerPrefs.GetInt(isMusicOn);
        if (MusicStatus == 1)
        {
            SoundManager.Instance.PlayMusic();
            btnMusic.GetComponent<Image>().sprite = itemData.imgbtnMusicOn;
        }
        else
        {   
            SoundManager.Instance.MuteMusic();
            btnMusic.GetComponent<Image>().sprite = itemData.imgbtnMusicOff;
        }
       
        
    }
    private void OnValidateSound()
    {
        SoundStatus = PlayerPrefs.GetInt(isSoundOn);
        if (SoundStatus == 1)
        {
            canPlayFxSound = true;
            btnSound.GetComponent<Image>().sprite = itemData.imgbtnSoundOn;
        }
        else
        {
            canPlayFxSound = false;
            btnSound.GetComponent<Image>().sprite = itemData.imgbtnSoundOff;
        }
    }    
    public void ClickSound()
    {
        soundClick = PlayerPrefs.GetInt(isSoundOn);
        soundClick++;
        SoundManager.Instance.PlayTap();
        if (soundClick % 2 == 0)
        {
            SetSoundOff();
        }
        else
        {
            SetSoundOn();
        }
        OnValidateSound();
    }
    public void ClickMusic()
    {
        musicClick = PlayerPrefs.GetInt(isMusicOn);
        musicClick++;
        SoundManager.Instance.PlayTap();
        if (musicClick % 2 == 0)
        {
            SetMusicOff();
        }
        else
        {
            SetMusicOn();
        }
        ValidateMusic();
    }
   
}
