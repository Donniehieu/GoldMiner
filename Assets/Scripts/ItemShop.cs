using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ItemShop : MonoBehaviour
{
    public TextMeshProUGUI txtNameItem;

    public TextMeshProUGUI txtPrice;

    public int price;

    public Image itemSprite;

    public int id;

    [SerializeField] Button btn;
    [SerializeField] ItemShopInstance shopInstance;
    [SerializeField] ShopController shopController;
    [SerializeField] UIGamePlay uiGamePlay;
    [SerializeField] ShoperAnimation shoperAnimation;
    
    private void Awake()
    {   
        if(shopInstance==null)
        shopInstance = FindObjectOfType<ItemShopInstance>();
        shopController = FindObjectOfType<ShopController>();
        uiGamePlay = FindObjectOfType<UIGamePlay>();
        shoperAnimation = FindObjectOfType<ShoperAnimation>();
        
    }
    public void ClickBuy()
    {
        shopInstance.panelshopTalk.SetActive(true);
        if( shopInstance.curCoin< price)
        {
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipFail); 
          shopInstance.txtTalk.text= shopInstance.ReturnNotEnoughMoneyText();
          shoperAnimation.PlayShopGuide();
        }
        else
        {
            shopController.isBuy = true;
            shopInstance.curCoin -= price;
            shopInstance.txtTalk.text = shopInstance.ReturnHappyText();
            shoperAnimation.PlayShopHappy();
            btn.interactable = false;
            shopController.SaveItemBuy(id);
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipCongQua);          
        }
        DOVirtual.DelayedCall(0.5f, () => DeactivePanelChat());
    }

    private void DeactivePanelChat()
    {
        shopInstance.panelshopTalk.SetActive(false);    
    }
 }
