using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EffectControler : MonoBehaviour
{
    public UIGamePlay uIGamePlay;
    public RectTransform TargetScore;
    public RectTransform OriginalScore;
    public RectTransform OriginalTime;
    public RectTransform rectScore;
    public RectTransform TargetTime;
    public RectTransform rectTime;
    public GameObject boomBlow;


    private void Reset()
    {
        uIGamePlay = FindObjectOfType<UIGamePlay>();
        TargetScore = uIGamePlay.txtCurrentScore.GetComponent<RectTransform>();
        rectScore = uIGamePlay.txtAddScore.GetComponent<RectTransform>();
        rectTime = uIGamePlay.txtAddTime.GetComponent<RectTransform>();
        TargetTime = uIGamePlay.txtTime.GetComponent<RectTransform>();
        boomBlow = Resources.Load<GameObject>("Prefabs/BoomExplosion");
    }
   
    public void SpawnExplosion( Vector3 pos)
    {
        GameObject ob = Instantiate(boomBlow);
        ob.transform.position = pos;
        DOVirtual.DelayedCall(0.5f, () =>
        {
            ob.gameObject.SetActive(false);
        });
    }


    private void SetActiveScoreText()
    {
        
        rectScore.DOAnchorPos(TargetScore.anchoredPosition, 0.5f).OnComplete(() => ReturnText());
       
    }
    private void SetActiveTimeText()
    {
        
        rectTime.DOAnchorPos(TargetTime.anchoredPosition, 0.5f).OnComplete(() => ReturnTextTime());
    }

    private void ReturnTextTime()
    {
        rectTime.DOAnchorPos(OriginalTime.anchoredPosition, 0.1f);
        rectTime.gameObject.SetActive(false);
    }
   
    private  void ReturnText()
    {
        rectScore.DOAnchorPos(OriginalScore.anchoredPosition, 0.1f);
        rectScore.gameObject.SetActive(false);
    }
    public void GetScore()
    {
        
        rectScore.gameObject.SetActive(true);
        
        DOVirtual.DelayedCall(0.5f, () => SetActiveScoreText());
    }
    public void GetTime()
    {
     
        rectTime.gameObject.SetActive(true);
       
        DOVirtual.DelayedCall(0.5f, () => SetActiveTimeText());
        
    }
}
