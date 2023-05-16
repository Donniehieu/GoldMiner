using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeControler : MonoBehaviour
{
    [SerializeField] SceneLoading sceneLoading;
    private void Awake()
    {
        sceneLoading = FindObjectOfType<SceneLoading>();
    }
    public void ClickGuide()
    {
        sceneLoading.LoadGuidePage();
        SoundManager.Instance.PlayTap();
    }

    public void ClickPlay()
    {
        sceneLoading.LoadLevelPage();
        SoundManager.Instance.PlayTap();
    }

    public void ClickSetting()
    {
        sceneLoading.LoadSettingPage();
        SoundManager.Instance.PlayTap();
    }

    public void ClickRateUs()
    {
        SoundManager.Instance.PlayTap();
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.hieu.hieu");
    }
}
