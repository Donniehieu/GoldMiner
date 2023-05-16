using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LineControl : MonoBehaviour
{
    [SerializeField] Transform startTrans;
    [SerializeField] LineRenderer lineRender;

    [SerializeField] Transform lineTrans;



    public  Hook hook;
    public Transform endTrans;
    private float speed = 1.3f;

    private float angleMax = 70f;

    private float speedDrop = 3f;

    public TypeMine type;

    private float minLine, maxLine;

    private float speedDragUp;

    public bool isDrag;
    public float SpeedUp
    {
        get { return speedDragUp; }
        set { speedDragUp = value; }
    }

    [SerializeField] UIGamePlay uIGamePlay;

    [SerializeField] EffectControler effectController;

    [SerializeField] CharacterAnimation characterAnimation;

    [SerializeField] ShopController shopController;

    [SerializeField] Transform originalPos;

    [SerializeField] PauseController pauseController;

    [SerializeField] PopupController popupController;

    private bool canMine;
  
    private void OnEnable()
    {
        canMine = false;
        minLine = 0.7f;
        maxLine = 13;
        startTrans = GameObject.Find("StartPoint").transform;           
        lineRender = GetComponentInChildren<LineRenderer>();
        lineTrans = transform;
        GameManager.Instance.isPlaying = true; 
        hook = endTrans.GetComponentInChildren<Hook>();
        if (pauseController.isResume == false)
        {
            Replay();
        }
    }
    private void Replay()
    {
        ResetHook();
        DOVirtual.DelayedCall(0.3f, () =>
        {
            SetActiveLine();
            type = TypeMine.normal;
        });
    }
    private void DrawLine()
    {
        lineRender.SetPositions(new Vector3[] { startTrans.position, endTrans.position });
    }

    private void SwingHook()
    {
        endTrans.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sin(Time.time * speed) * angleMax));
        lineTrans.rotation= endTrans.rotation;
    }

    private void DropHook()
    {
        if (canMine == true)
        {
            characterAnimation.PlayDrop();
            SoundManager.Instance.effectAudio.loop = true;
            SoundManager.Instance.PlaySoundFx(SoundManager.Instance.clipList.clipThaDay);
            endTrans.Translate(Vector3.down * Time.deltaTime * speedDrop);
        }
    }

    private void DragUpHook()
    {
        SoundManager.Instance.effectAudio.loop = true;
        SoundManager.Instance.PlaySoundFx(SoundManager.Instance.clipList.clipKeoDay);
        endTrans.Translate(Vector3.up * Time.deltaTime * speedDragUp);
    }

    public enum TypeMine { dropHook, dragHook, normal};
    private void GetTypeMine()
    {
        switch (type)
        {
            case TypeMine.dropHook:DropHook();
               
                if (hook.isOutOfView==true || hook.isCollision==true|| GetLength()>maxLine ) type = TypeMine.dragHook;
                break;
            case TypeMine.dragHook: DragUpHook();
                isDrag = true;
                canMine = false;
                if (GetLength() <= minLine)
                {
                    if (hook.isCheap == true)
                    {
                        characterAnimation.PlaySad();
                        hook.isCheap = false;
                    }
                    else
                    {
                        characterAnimation.PlayIdle();
                    }
                    type = TypeMine.normal;
                }      
                break;
            case TypeMine.normal:
                canMine = true;
                OnCompleteDrag();
                ResetHook();
                SwingHook();
                break;
            default: 
                break;
        }
    }
    private float GetLength()
    {
       float lenghtLine = (endTrans.position - startTrans.position).magnitude;
       return lenghtLine;
    }

    public void ResetHook()
    {
        
        isDrag = false;
        hook.isCollision = false;        
        canMine = true;
        endTrans.localRotation = Quaternion.identity;
        endTrans.localPosition = originalPos.localPosition;
        if (SoundManager.Instance.isBlank == true)
        {
            
            SoundManager.Instance.effectAudio.Stop();
        }
        speedDragUp = 4f;
        speedDrop = 4f;
        speed = 1;
        
    }
    public void ClickMine()
    {
        if (type != TypeMine.normal)
            return;
        type = TypeMine.dropHook;
    }
    private void OnCompleteDrag()
    {
        
        if (!hook.transform.GetComponentInChildren<ItemOb>())
            return;
        if (hook.addScore != 0)
        {
            effectController.GetScore();
        }
        if (hook.transform.GetComponentInChildren<Clock>())
        {
            effectController.GetTime();
        }
        if (hook.isCheap == true)
        {
            characterAnimation.PlaySad();
            hook.isCheap = false;
        }
        if (hook.isRare == true)
        {
            characterAnimation.PlayHappy();
            hook.isRare = false;
        }             
        uIGamePlay.CurrentScore += hook.addScore;
        SoundManager.Instance.PlaySoundFx(SoundManager.Instance.clipList.clipCongTien);
        SoundManager.Instance.effectAudio.loop = false;
        Destroy(hook.transform.GetChild(hook.transform.childCount-1).gameObject);
        

    }
    private void SetActiveLine()
    {
        endTrans.gameObject.SetActive(true);
    }

  
    private void Update()
    {   
        DrawLine();        
        GetTypeMine();
    }
}
