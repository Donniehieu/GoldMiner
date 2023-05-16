using UnityEngine;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] GameObject homePage;

    [SerializeField] GameObject levelPage;

    [SerializeField] GameObject guidePage;

    [SerializeField] GameObject settingPage;

    [SerializeField] GameObject uiController;

    public GameObject gamePlayPage;

    public GameObject uiGamePlay;

    [SerializeField] GameManager gameManager;

    [SerializeField] GameEvent gameEvent;

    [SerializeField] PopupController popupController;

    [SerializeField] LevelInstance levelInstance;

    public GameObject shopScene;

    
 
    private void Reset()
    {
        SetUp();
    }

    private void SetUp()
    {
        uiController = GameObject.Find("UIController");
        levelPage = uiController.transform.Find("Level").gameObject;
        settingPage = uiController.transform.Find("Setting").gameObject;
        guidePage = uiController.transform.Find("Guide").gameObject;
        homePage = uiController.transform.Find("Home").gameObject;
        gamePlayPage = GameObject.Find("GamePlay");
        gameManager = GetComponent<GameManager>();
        popupController = FindObjectOfType<PopupController>();
      
        
    }

    private void Awake()
    {
        LoadHomePage();
    }
    public void LoadHomePage()
    {
        SoundManager.Instance.PlayTap();
        homePage.SetActive(true);
        levelPage.SetActive(false);
        guidePage.SetActive(false);
        settingPage.SetActive(false);
        gamePlayPage.SetActive(false);
        gameManager.isPlaying = false;
        
    }

    public void LoadLevelPage()
    {
        homePage.SetActive(false);
        levelPage.SetActive(true);
        gameManager.isPlaying = false;

    }
    
    public void LoadGuidePage()
    {
        homePage.SetActive(false);       
        guidePage.SetActive(true);
        gameManager.isPlaying = false;
    }
    public void LoadSettingPage()
    {
        homePage.SetActive(false);       
        settingPage.SetActive(true);
        gamePlayPage.SetActive(false);
        gameManager.isPlaying = false;
       
    }
    public void LoadGamePlay()
    {   

        levelPage.SetActive(false);
        settingPage.SetActive(false);
        gamePlayPage.SetActive(true);
        shopScene.SetActive(false);
        uiGamePlay.SetActive(true);
        gameManager.isPlaying = true;
       
    }
    public void ShowShop()
    {
        SoundManager.Instance.PlayTap();
        gameManager.isPlaying = false;
        uiGamePlay.SetActive(false);
        levelInstance.ClearMap();
        gamePlayPage.SetActive(false);
        popupController.WinHide();
        shopScene.SetActive(true);
    }

}
