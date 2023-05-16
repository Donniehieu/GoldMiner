using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;

    public AnimationClipController animationClipController;

   
    private void Reset()
    {
        animator = GetComponent<Animator>();
        animationClipController = Resources.Load<AnimationClipController>("Scriptable/AnimationClip");
    }
    private void PlayAnimation(AnimationClip animationClip)
    {
        if (animator.isActiveAndEnabled==true)
        {
            string clip = animationClip.name;
            animator.Play(clip);
        } 
        
    }

   
    public void PlayHappy()
    {
        PlayAnimation(animationClipController.CharHappy);

    }

    public void PlayEnergy()
    {
        PlayAnimation(animationClipController.CharEnergy);
    }

    public void PlayHeavy()
    {
        PlayAnimation(animationClipController.CharHeavy);
    }

    public void PlayLight()
    {
        PlayAnimation(animationClipController.CharLight);
    }

    public void PlayNormal()
    {
        PlayAnimation(animationClipController.CharNormal);
    }
    public void PlayDropTnt()
    {
        PlayAnimation(animationClipController.CharDropTnt);
    }

    public void PlayDrop()
    {
        PlayAnimation(animationClipController.CharDrop);
    }

    public void PlaySad()
    {
        PlayAnimation(animationClipController.CharSad);
    }
    public void PlayIdle()
    {
        PlayAnimation(animationClipController.CharIdle);
    }
}
