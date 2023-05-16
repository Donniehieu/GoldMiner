using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Dynamite : MonoBehaviour
{
    [SerializeField] DynamiteController dynamiteController;
   
    private void OnEnable()
    {
        dynamiteController = FindObjectOfType<DynamiteController>();
        
        dynamiteController.DynamiteMove();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemOb>())
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
        
    }

    
}
