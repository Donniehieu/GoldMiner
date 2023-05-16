using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemGui : MonoBehaviour
{
    public int idItem;

    [SerializeField] GuideControler guideControler;

    private void Awake()
    {
        guideControler = FindObjectOfType<GuideControler>();
    }
    public void ClickItem()
    {
        SoundManager.Instance.PlayTap();
        guideControler.ShowItemInfo(idItem);
    }
}
