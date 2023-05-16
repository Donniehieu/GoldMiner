using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DynamiteController : MonoBehaviour
{
    
    [SerializeField] Transform endPoint;
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject dynamiteItem;
    [SerializeField] LineControl lineControl;
    [SerializeField] Hook hook;
    [SerializeField] UIGamePlay uIGamePlay;
    [SerializeField] CharacterAnimation characterAnimation;
    [SerializeField] EffectControler effectController;
   

    private void Reset()
    {
        effectController = FindObjectOfType<EffectControler>();
    }
    public void DynamiteMove()
    {
        effectController.SpawnExplosion(endPoint.position);
        dynamiteItem.transform.DOMove(endPoint.position, 0.4f).OnComplete(()=> InstantiateBlow());

    }
    public void InstantiateBlow()
    {
       
        dynamiteItem.SetActive(false);
        dynamiteItem.transform.DOMove(startPoint.position, 0.1f);       
    }
    public void UseBoom()
    {
        if (uIGamePlay.DynamiteCount <= 0) return;
        if (hook.isCollision == true)
        {
            characterAnimation.PlayDropTnt();
            uIGamePlay.DynamiteCount--;
            dynamiteItem.SetActive(true);
            lineControl.SpeedUp = 7;
            characterAnimation.PlayLight();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipNoTnt);
            SoundManager.Instance.isBlank = true;
        }
        
    }
}
