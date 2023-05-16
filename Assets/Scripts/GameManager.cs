using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class GameManager : MonoBehaviour

{
    [SerializeField] UIControler uIControler;

    [SerializeField] PopupController popUpController;

    public UIGamePlay uIGamePlay;

    public ShopController shopController;
  
    public LineControl lineController;
    private static GameManager instance;
    public static GameManager Instance

    {
        get
        {
            {

                if (instance == null)
                {
                    GameObject ob = new GameObject();
                    ob.name = "GameManager";

                    instance = ob.AddComponent<GameManager>();
                    DontDestroyOnLoad(ob);

                }
            } return instance;
        }
    }

    public string getPower = "GetPower";

    public bool isPlaying;

    private GameEvent gameEvent;

    [SerializeField] SpriteRenderer bgSprite;

    [SerializeField] SOItem spriteItem;
    private void Reset()
    {
        uIControler = FindObjectOfType<UIControler>();
        shopController = FindObjectOfType<ShopController>();
        uIGamePlay = FindObjectOfType<UIGamePlay>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(gameObject);
        }
        uIControler = FindObjectOfType<UIControler>();
        shopController = FindObjectOfType<ShopController>();
        uIGamePlay = FindObjectOfType<UIGamePlay>();
        popUpController = FindObjectOfType<PopupController>();
    }

    private void OnEnable()
    {
        gameEvent = GetComponent<GameEvent>();

        gameEvent.startGame += StartGame;

    }
    public void WinGame()
    {
        popUpController.WinShow();
        SoundManager.Instance.PlayWinLose(SoundManager.Instance.clipList.clipWin);
        ResetStatus();
        StopCoroutine(CountDownTime());

    }

    public void LoseGame()
    {
        popUpController.LoseShow();
        SoundManager.Instance.PlayWinLose(SoundManager.Instance.clipList.clipFail);
        ResetStatus();
        StopCoroutine(CountDownTime());

        
    }


    public void StartGame()
    {
        StopAllCoroutines();
        uIControler.UIGamePlay.CurrentTime = 60;
        StartCoroutine(CountDownTime());
        isPlaying = true;
        CheckAllItemBuy();
        lineController.ResetHook();
        SetDynamite();

    }


    public IEnumerator CountDownTime()
    {
        while (uIControler.UIGamePlay.CurrentTime > 0)
        {
            yield return new WaitForSeconds(1);
            uIControler.UIGamePlay.CurrentTime -= 1;            
            CheckEarlyWin();
        }
        CheckWinLose();
    }

    private void CheckEarlyWin()
    {
        if (isPlaying == false)
        {
            StopCoroutine(CountDownTime());
            return;
        }
        if (popUpController.levelInstance.transform.childCount == 0 &&
             lineController.hook.transform.childCount == 0)
            {
                if (uIGamePlay.CurrentScore >= uIGamePlay.TargetScore)
                {
                    WinGame();
                }
                else
                {
                    LoseGame();
                }
            }
       
    }
    private void CheckWinLose()
    {
        if (isPlaying == false)
        {
            StopCoroutine(CountDownTime());
            return;
        }
        if (uIControler.UIGamePlay.CurrentTime <= 0)
        {
            uIControler.UIGamePlay.CurrentTime = 0;
            if (uIControler.UIGamePlay.CurrentScore >= uIControler.UIGamePlay.TargetScore)
            {
                WinGame();
            }
            else
            {
                LoseGame();
            }
            
        }
        

    }

    private void ResetStatus() {

        shopController.ClearAllConsumeItem();
        SoundManager.Instance.MuteSoundFx();
        SoundManager.Instance.effectAudio.loop = false;
        isPlaying = false;
    }
    public void WinGameNow()
    {
        uIControler.UIGamePlay.CurrentScore = 100000;
        uIControler.UIGamePlay.CurrentTime = 1;

    }
    public void LoseGameNow()
    {
        uIControler.UIGamePlay.CurrentScore = 0;
        uIControler.UIGamePlay.CurrentTime = 1;
    }

    private void AddTime()
    {
        uIControler.UIGamePlay.CurrentTime += 10;
    }

    public void ChangeBackGround(int idLevel)
    {
        if(0<idLevel&& idLevel <= 45)
        {
            bgSprite.sprite = spriteItem.imgBGCountrySide;
        }
        else 
        {
            bgSprite.sprite = spriteItem.imgBGDesert;
        }
    }


    private void SetDynamite()
    {
        if (uIControler.UIGamePlay.DynamiteCount > 0)
        {
            uIControler.UIGamePlay.dynamiteItem.SetActive(true);

        }
        else
        {
            uIControler.UIGamePlay.dynamiteItem.SetActive(false);
        }
    }

    public int GetPower()
    {
        return 7;
    }
    private void CheckAllItemBuy()
    {
        uIControler.UIGamePlay.DynamiteCount = PlayerPrefs.GetInt(shopController.isBuyDynamite);
        if (shopController.isClock == true)
        {
            AddTime();
        }
    }
    private void Update()
    {   if (isPlaying == false) return;
        
    } 
    
}
