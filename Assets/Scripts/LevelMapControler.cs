using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMapControler : MonoBehaviour
{
    [SerializeField] LevelSelect levelSelectMap;

    [SerializeField] UIControler uiController;

    [SerializeField] GameObject btnNext;

    [SerializeField] GameObject btnBack;

  
    public int maxPage;
    public int idPage;
    [Header("Số lượng level")]
    public int maxLevel;
    [Header("Số lượng level/ page")]
    public int maxItem;
    public int currentLevel;
    public string savedMaxLevel = "saveMaxLevel";
    public int curidPage;
    public int maxCurrentLevel;

    public int curLevel
    {
        get { return currentLevel; }
        set { currentLevel = value;            
           
            uiController.UIGamePlay.ShowLevelText(currentLevel);
        }
    }

    private void Reset()
    {
        levelSelectMap = GetComponent<LevelSelect>();
        uiController = FindObjectOfType<UIControler>();
    }
    private void Awake()
    {    
        maxCurrentLevel = PlayerPrefs.GetInt(savedMaxLevel);
        if (maxCurrentLevel == 0)
        {
            maxCurrentLevel = 1;
            curLevel = maxCurrentLevel;
            PlayerPrefs.SetInt(savedMaxLevel, 1);
        }
        SetProperties();
        OnValidateShow(idPage);
        
    }

    private void SetProperties()
    {
        maxItem = 15;
        maxLevel = 75;
        idPage = GetIdPage();
        curidPage = idPage;
        maxPage = maxLevel / maxItem;
    }
    private int GetIdPage()
    {
       
        if(maxCurrentLevel % maxItem == 0)
        {
            return maxCurrentLevel / maxItem;
        }
        else
        {
            return maxCurrentLevel / maxItem + 1;
        }    
    }
    public void ClickNextPage()
    {
        if(idPage<maxPage) idPage++;
        SoundManager.Instance.PlayTap();
        curidPage = idPage;
        OnValidateShow(curidPage);
      
    }
    public void ClickBackPage()
    {
        if (idPage > 1) idPage--;
        SoundManager.Instance.PlayTap();
        curidPage = idPage;
        OnValidateShow(curidPage);
       
    }
    public void OnValidateShow(int id)
    {

         if (id == 1)
        {
            btnBack.SetActive(false);
            btnNext.SetActive(true);
        }
        if (id == maxPage)
        {
            btnNext.SetActive(false);
            btnBack.SetActive(true);
        }
        if (id>1  && id< maxPage)
        {
            btnBack.SetActive(true);
            btnNext.SetActive(true);
        }
        SetIdLevel();
        LockAllItem();
    }
    private void SetIdLevel()
    {
        if (levelSelectMap.listLevel.Count == 0)
            return;
        for (int i = 0; i < levelSelectMap.listLevel.Count; i++)
        {
           levelSelectMap.listLevel[i].GetComponent<Level>().idLevel = ((idPage - 1) *maxItem) + (i + 1);
           levelSelectMap.listLevel[i].GetComponent<Level>(). txtLevel.text = levelSelectMap.listLevel[i].GetComponent<Level>().idLevel.ToString();
            
        }       
    }

    private void UnlockLevel()
    {
        maxCurrentLevel = PlayerPrefs.GetInt(savedMaxLevel);
        int id = maxCurrentLevel - (idPage - 1) * maxItem - 1;
        
        if (maxCurrentLevel < maxItem * curidPage)
        {
            for (int i = 0; i <= id; i++)
            {
                levelSelectMap.listLevel[i].GetComponent<Button>().interactable = true;
            }
        }       
        if(maxCurrentLevel >= maxItem * curidPage)
        {
            for (int i = 0; i < levelSelectMap.listLevel.Count ; i++)
            {
                levelSelectMap.listLevel[i].GetComponent<Button>().interactable = true;
            }
        }
    }
    private void LockAllItem()
    {
        for (int i = 0; i < levelSelectMap.listLevel.Count; i++)
        {
            levelSelectMap.listLevel[i].GetComponent<Button>().interactable = false;
        }
        UnlockLevel();
    }
}
