using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuideControler : MonoBehaviour
{
    [SerializeField] GameObject popupGuide;

    [SerializeField] SOItem itemData;

    [SerializeField] GameObject panelShowInfo;
    private void Awake()
    {
        itemData = Resources.Load<SOItem>("Scriptable/ItemDB");
        panelShowInfo = GameObject.Find("PanelShow");
        ShowItemInfo(1);
    }
    public void ShowItemInfo(int id)
    {
        switch (id)
        {
            case 1:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgVangNho;
                break;
            case 2:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgVangVua;
                break;
            case 3:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgVangSieuLon;
                break;
            case 4:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgKimCuong;
                break;
            case 5:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgChuot;
                break;
            case 6:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgDaNho;
                break;
            case 7:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgDaLon;
                break;
            case 8:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgXuongLon;
                break;
            case 9:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgTuiMayMan;
                break;
            case 10:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgTnt;
                break;
            case 11:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgBoom;
                break;
            case 12:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgClock;
                break;
            case 13:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgCayMayMan;
                break;
            case 14:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgNuocDanhBong;
                break;
            case 15:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgVoucher;
                break;
            case 16:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgPower;
                break;
            default:
                panelShowInfo.GetComponent<Image>().sprite = itemData.imgVangNho;
                break;
        }
    }

}
