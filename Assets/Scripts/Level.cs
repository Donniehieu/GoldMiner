using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level : MonoBehaviour
{
    public int idLevel;
    public TextMeshProUGUI txtLevel;
    [SerializeField] LevelMapControler levelMapController;
    [SerializeField] LevelInstance levelInstance;
    [SerializeField] SceneLoading sceneLoading;
    [SerializeField] GameEvent gameEvent;
    

    private void OnEnable()
    {
        levelMapController = FindObjectOfType<LevelMapControler>();
        txtLevel = GetComponentInChildren<TextMeshProUGUI>();
        levelInstance = FindObjectOfType<LevelInstance>();
        sceneLoading = FindObjectOfType<SceneLoading>();
        gameEvent = FindObjectOfType<GameEvent>();
    }
    public void ClickLevel()
    {
        SoundManager.Instance.PlayTap();
        levelMapController.curLevel = idLevel;    
        sceneLoading.LoadGamePlay();
        levelInstance.LoadMap(idLevel);    
        gameEvent.startGame?.Invoke();
    }

    
}
