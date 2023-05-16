using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] SceneLoading sceneLoading;

    [SerializeField] GameObject pausePanel;

    [SerializeField] GameObject popupPanel;  

    [SerializeField] GameEvent gameEvent;

    [SerializeField] LevelInstance levelInstance;

    [SerializeField] LevelMapControler levelMapControler;

    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject hook;

    [SerializeField] ShopController shopController;

    public bool isResume;

    
    private void Reset()
    {
        sceneLoading = FindObjectOfType<SceneLoading>();
        pausePanel = GameObject.Find("Pause");
        popupPanel = GameObject.Find("Popup");
        sceneLoading = FindObjectOfType<SceneLoading>();
        gameEvent = FindObjectOfType<GameEvent>();
        gameManager = FindObjectOfType<GameManager>();
        shopController = FindObjectOfType<ShopController>();
    }
   
    public void Replay()
    {
        SoundManager.Instance.PlayTap();
        ClosePause();                
        levelInstance.LoadMap(levelMapControler.curLevel);        
        gameEvent.startGame?.Invoke();
        
    }

    public void ClickHome()
    {
        SoundManager.Instance.PlayTap();
        shopController.ClearAllConsumeItem();
        ClosePause();
        sceneLoading.uiGamePlay.SetActive(false);
        levelInstance.ClearMap();
        sceneLoading.LoadHomePage();
        GameManager.Instance.uIGamePlay.lastScore = 0;
    }

    public void Resume()
    {
        SoundManager.Instance.PlayTap();
        Time.timeScale = 1;
        isResume = true;
        ClosePause();
    }

    public void ClickPause()
    {
        SoundManager.Instance.PlayTap();
        isResume = false;
        gameManager.StopCoroutine(gameManager.CountDownTime());
        gameManager.isPlaying = false;
        Time.timeScale = 0;       
        SoundManager.Instance.MuteSoundFx();        
        ShowPause();
    }
    private void ShowPause()
    {
        popupPanel.SetActive(true);
        pausePanel.SetActive(true);
    }

    private void ClosePause()
    {
        
        sceneLoading.gamePlayPage.SetActive(true);
        popupPanel.SetActive(false);
        pausePanel.SetActive(false);
        GameManager.Instance.isPlaying = true;
        Time.timeScale = 1;

    }
}
