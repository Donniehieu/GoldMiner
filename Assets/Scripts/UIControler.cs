using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControler : MonoBehaviour
{
    public UIGamePlay UIGamePlay;
    private void Reset()
    {
        UIGamePlay = FindObjectOfType<UIGamePlay>();
    }
   
}
