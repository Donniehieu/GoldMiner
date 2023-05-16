using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIGamePlay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtTargetScore;

    public TextMeshProUGUI txtCurrentScore;

    public TextMeshProUGUI txtTime;

    [SerializeField] TextMeshProUGUI txtLevel;

    [SerializeField] Button btnPause;

    [SerializeField] UIControler uiController;

    [SerializeField] SceneLoading sceneLoading;

    public GameObject dynamiteItem;

    [SerializeField] TextMeshProUGUI txtDynamite;

    [SerializeField] ShopController shopController;

    private int curDynamite;

    public int lastScore;
    private void Awake()
    {
        shopController = FindObjectOfType<ShopController>();
        uiController = GetComponent<UIControler>();
        sceneLoading = FindObjectOfType<SceneLoading>();
    }


    public int DynamiteCount
    {
        get { return curDynamite; }
        set { curDynamite = value;
            PlayerPrefs.SetInt(shopController.isBuyDynamite, curDynamite);
            if (curDynamite > 0)
            {
                dynamiteItem.SetActive(true);
               
            }
            else
            {
                dynamiteItem.SetActive(false);
            }
            txtDynamite.text = curDynamite.ToString();

        }
    }

    public GameObject txtAddScore;

    public GameObject txtAddTime;

    [SerializeField] GameObject txtTimeUrgent;

    private float curTime; 

    public float CurrentTime
    {
        get { return curTime; }
        set { curTime = value;
            txtTime.text =((int)curTime).ToString();
        }
    }
    private int targetScore;
    public int TargetScore
    {
        get { return targetScore; }
        set { targetScore = value;
            txtTargetScore.text = targetScore.ToString();
        }
    }
    private int curScore;

    public int CurrentScore
    {
        get { return curScore; }
        set { curScore = value;
            txtCurrentScore.text = curScore.ToString();
        }
    }
  
    private void Reset()
    {
        txtLevel = GameObject.Find("txtLevel").GetComponent<TextMeshProUGUI>();
        txtTime = GameObject.Find("txtTime").GetComponent<TextMeshProUGUI>();
        txtTargetScore = GameObject.Find("txtTargetScore").GetComponent<TextMeshProUGUI>();
        txtCurrentScore = GameObject.Find("txtCurrentScore").GetComponent<TextMeshProUGUI>();
        btnPause = GameObject.Find("btnPause").GetComponent<Button>();
       
    }
    public void ShowLevelText(int level)
    {
        txtLevel.text = level.ToString();
    }
    private void OnDisable()
    {
        dynamiteItem.SetActive(false);
    }

    public void AddScore()
    {
        CurrentScore *= 2;
        sceneLoading.ShowShop();
    }
}
