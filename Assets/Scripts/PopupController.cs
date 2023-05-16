using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] GameObject popupPanel;

    [SerializeField] GameObject winPanel;

    [SerializeField] GameObject losePanel;

    [SerializeField] GameEvent gameEvent;

    public LevelInstance levelInstance;

    [SerializeField] LevelMapControler levelMapController;

    [SerializeField] SceneLoading sceneLoading;

    [SerializeField] ShoperAnimation shoperAnimation;

    [SerializeField] ShopController shoperController;
   
    [SerializeField] UIGamePlay uiGamePlay;


    private int maxLevel;

    private void Reset()
    {
        gameEvent = FindObjectOfType<GameEvent>();
        sceneLoading = FindObjectOfType<SceneLoading>();
        shoperController = FindObjectOfType<ShopController>();      
        uiGamePlay = FindObjectOfType<UIGamePlay>();
    }

    private void Start()
    {
       
    }
    public void WinShow()
    {
        popupPanel.SetActive(true);
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void WinHide()
    {
        Time.timeScale = 1;
        popupPanel.SetActive(false);
        winPanel.SetActive(false);

    }

    public void LoseShow()
    {
        Time.timeScale = 0;
        popupPanel.SetActive(true);
        losePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void LoseHide()
    {
        Time.timeScale = 1;
        popupPanel.SetActive(false);
        losePanel.SetActive(false);
    }
   

   private void PLayNextLevel()
    {
        
        WinHide();        
        levelMapController.curLevel += 1;
        maxLevel = PlayerPrefs.GetInt(levelMapController.savedMaxLevel);
        if (levelMapController.curLevel > maxLevel)
        {
            PlayerPrefs.SetInt(levelMapController.savedMaxLevel, levelMapController.curLevel);
        }
        
        uiGamePlay.lastScore = uiGamePlay.CurrentScore;
        sceneLoading.shopScene.SetActive(false);
        sceneLoading.uiGamePlay.SetActive(true);
        sceneLoading.gamePlayPage.SetActive(true);        
        levelInstance.LoadMap(levelMapController.curLevel);
        gameEvent.startGame?.Invoke();
       
    }
   
    public void ClickNext()
    {   

        if (shoperController.isBuy == false)
        {
            shoperAnimation.PlayShopAngry();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetDa);
        }
        else
        {
            shoperAnimation.PlayShopHappy();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipMucTieu);            
        }
        
        DOVirtual.DelayedCall(0.5f, () =>
        {
            PLayNextLevel();
            shoperController.isBuy = false;
        });
        
    }

    public void ShareFb()
    {
        SoundManager.Instance.PlayTap();
    }
}
