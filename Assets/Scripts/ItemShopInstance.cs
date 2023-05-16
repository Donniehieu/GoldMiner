using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemShopInstance : MonoBehaviour
{
    public List<ItemShopList> listItemBuy = new List<ItemShopList>();
    public List<ItemShopList> listShow = new List<ItemShopList>();
    public List<GameObject> listContainer = new List<GameObject>();
    public ItemShopList cloverShop;
    public ItemShopList energyShop;
    public ItemShopList clockShop;
    public ItemShopList polishShop;
    public ItemShopList rockVoucher;
    public ItemShopList tntShop;
    public LevelMapControler levelMapController;
    public UIGamePlay uIGamePlay;
    public int level;
    [SerializeField] TextMeshProUGUI txtCurCoin;
    public GameObject panelshopTalk;
    public TextMeshProUGUI txtTalk;    
    public int curCoin
    {
        get { return uIGamePlay.CurrentScore; }
        set { uIGamePlay.CurrentScore = value;
            txtCurCoin.text = uIGamePlay.CurrentScore.ToString();
        }
    }
    private void Awake()
    {
        uIGamePlay = FindObjectOfType<UIGamePlay>();
        cloverShop = Resources.Load<ItemShopList>("Scriptable/Clover");
        energyShop = Resources.Load<ItemShopList>("Scriptable/Energy");
        clockShop = Resources.Load<ItemShopList>("Scriptable/Clock");
        polishShop = Resources.Load<ItemShopList>("Scriptable/Polish");
        rockVoucher = Resources.Load<ItemShopList>("Scriptable/RockVoucher");
        tntShop = Resources.Load<ItemShopList>("Scriptable/Dynamite");
    }
    private void OnEnable()
    {
        panelshopTalk.SetActive(false);
        SetItemShow();
        curCoin = uIGamePlay.CurrentScore;
        
    } 
    private void SetItemShow()
    {
        listItemBuy.Add(cloverShop);
        listItemBuy.Add(energyShop);
        listItemBuy.Add(clockShop);
        listItemBuy.Add(polishShop);
        listItemBuy.Add(rockVoucher);
        listItemBuy.Add(tntShop);
        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, listItemBuy.Count);
           
            listShow.Add(listItemBuy[rand]);
            ItemShop itemShop = listContainer[i].GetComponent<ItemShop>();
            itemShop.itemSprite.sprite = listShow[i].itemSprite;
            int randPrice = Random.Range(listShow[i].minPrice, listShow[i].maxPrice);
            itemShop.price = AddVariable()* randPrice;
            itemShop.txtPrice.text = itemShop.price.ToString();
            itemShop.txtNameItem.text = listShow[i].itemName;
            itemShop.id = listShow[i].idItem;
            itemShop.itemSprite.GetComponent<Image>().SetNativeSize();
            listItemBuy.RemoveAt(rand);
        }
    }
    private int AddVariable()
    { level = levelMapController.currentLevel;
        if ( level<= 15)
        {
            return 1;
        }
        else if (level <= 30)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    public string ReturnHappyText()
    {
        ShoperPilot shoperTalk = new ShoperPilot();
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0: return shoperTalk.veryHappy1;
            case 1: return shoperTalk.veryHappy2;
            case 2: return shoperTalk.happy1;
            case 3: return shoperTalk.happy2;
            default: return null;             
        }
    }
    public int CurCoinSet;
    private void SetCoin()
    {
        curCoin = CurCoinSet;
    }
    public string ReturnUpSetText()
    {
        ShoperPilot shoperTalk = new ShoperPilot();
        int rand = Random.Range(0,2);
        switch (rand)
        {
            case 0: return shoperTalk.upset1;
            case 1: return shoperTalk.upset2;               
            default: return null;               
        }
    }

    public string ReturnWinText()
    {
        ShoperPilot shoperTalk = new ShoperPilot();
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: return  shoperTalk.win1;
            case 1: return  shoperTalk.win2;
            case 2: return  shoperTalk.win3;
            default: return null;
        }
    }
    public string ReturnLoseText()
    {
        ShoperPilot shoperTalk = new ShoperPilot();
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: return  shoperTalk.lose1;
            case 1: return  shoperTalk.lose2;
            case 2: return  shoperTalk.lose3;
            default: return null;
        }
    }

    public string ReturnNotEnoughMoneyText()
    {
        ShoperPilot shoperTalk = new ShoperPilot();
        return shoperTalk.getMoreMoney;
    }

    private void OnDisable()
    {
        panelshopTalk.SetActive(false);
        for (int i = 0; i < listContainer.Count; i++)
        {
            listContainer[i].GetComponentInChildren<Button>().interactable = true;
        }
        listItemBuy.Clear();
        listShow.Clear();
    }

}
