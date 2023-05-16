using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tnt : MonoBehaviour
{
   [SerializeField] BoxCollider2D _collider;

    

    public bool isExplosion;
    private void OnEnable()
    {
        _collider = GetComponent<BoxCollider2D>();      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hook>())
        {
            _collider.size = new Vector2(3, 3);
            isExplosion = true;
            //Keo trung boom thi se tat hieu ung keo
            SoundManager.Instance.isBlank = true;
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipNoTnt);
        }
        if (isExplosion == true)
        {
            if (collision.GetComponent<ItemOb>())
            {
                  
                    DOVirtual.DelayedCall(0.08f,()=> Destroy(gameObject));
                    Destroy(collision.gameObject);
               
            }
        }
        
    }

   

    private void OnDisable()
    {
        isExplosion = false;
    }
}
