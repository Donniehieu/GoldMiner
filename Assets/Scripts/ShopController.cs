using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] UIGamePlay uiGamePlay;
   
    public string isBuyDynamite = "Dynamite";

    public bool isClover, isDynamite, isClock, isPolish, isRockVoucher, isEnergy;

    public bool isBuy;

    public Button btnNext;

    private void Awake()
    {
        uiGamePlay = FindObjectOfType<UIGamePlay>();
    }
    public void SaveItemBuy(int itemBuy)
    {
       if(itemBuy == 0)
        {
            isClover = true;
        }
       if(itemBuy == 1)
        {
            isEnergy = true;
        }
        if (itemBuy == 2)
        {
            isClock = true;
        }
        if(itemBuy == 3)
        {
            isPolish = true;
        }
        if(itemBuy == 4)
        {
            isRockVoucher = true;
        }
        if (itemBuy == 5)
        {
            PlayerPrefs.SetInt(isBuyDynamite, 1);
            BuyDynamite();
        }
       
    }
    private void BuyDynamite()
    {
        uiGamePlay.DynamiteCount += 1;
    }
    public void ClearAllConsumeItem()
    {
        isClover = false;
        isEnergy = false;
        isPolish = false;
        isRockVoucher = false;
        isClock = false;
    }
    public void BuyItemBoom(int idItem)
    {
        SaveItemBuy(idItem);
    }



}
