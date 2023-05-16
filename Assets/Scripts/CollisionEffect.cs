using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
   [SerializeField] Animator anim;
   public AnimationClipController animationName;
   
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        animationName = Resources.Load<AnimationClipController>("Scriptable/AnimationClip");
       
    }
    
 
}
