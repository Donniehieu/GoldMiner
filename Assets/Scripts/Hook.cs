using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hook : MonoBehaviour
{
    public LineControl lineController;
    public bool isOutOfView;
    public bool isCollision;
    public UIGamePlay uIGamePlay;
    public int addScore;   
    [SerializeField] GameManager gameManager;
    [SerializeField] ShopController shopController;
    [SerializeField] DynamiteController dynamiteController;
    [SerializeField] EffectControler effectController;
    [SerializeField] CharacterAnimation characterAnim;
   
    public bool isCheap, isRare;

    private void Reset()
    {
        gameManager = FindObjectOfType<GameManager>();
        shopController = gameManager.shopController;
        lineController = GetComponentInParent<LineControl>();
        uIGamePlay = FindObjectOfType<UIGamePlay>();
        effectController = FindObjectOfType<EffectControler>();
        characterAnim = FindObjectOfType<CharacterAnimation>();        
    }
    private void OnBecameInvisible()
    {
        isOutOfView = true;
        SoundManager.Instance.isBlank = true;
        characterAnim.PlayLight();
    }
    private void OnBecameVisible()
    {
        isOutOfView = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TRANH KEO ROI MA LAI NO HOAC KEO TIEP
        if (isCollision == true || lineController.isDrag==true) return;
        
        if (collision.GetComponent<ItemOb>())
        {
            ItemOb itemCollision = collision.GetComponent<ItemOb>();
            isCollision = true;
            itemCollision.Collision();
            itemCollision.transform.SetParent(transform);
            itemCollision.transform.rotation = Quaternion.Slerp(itemCollision.transform.rotation, transform.rotation, Time.deltaTime*10);
             itemCollision.transform.position =new Vector2( transform.position.x, transform.position.y);
            //lineController.endTrans.position = itemCollision.transform.position;
            if (shopController.isEnergy == true)
            {
                lineController.SpeedUp = gameManager.GetPower();
            }
            else
            {
                lineController.SpeedUp = itemCollision.speed;
            }            
            addScore = itemCollision.point;
            uIGamePlay.txtAddScore.GetComponent<TextMeshProUGUI>().text ="+ " + itemCollision.point.ToString();
        
        }
        if (collision.GetComponent<Mouse>())
        {
            collision.GetComponent<Mouse>().speed = 0;
        }
        if (collision.GetComponent<Clock>())
        {           
            uIGamePlay.CurrentTime += 10;
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipDongHo);
            
        }
        if (collision.GetComponent<Tnt>())
        {
            effectController.SpawnExplosion(collision.transform.position);
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipNoTnt);
        }
        if (collision.CompareTag("Cheap"))
        {
            isCheap = true;
        }
        if (collision.CompareTag("Rare"))
        {
            isRare = true;
        }


    }

   
}
