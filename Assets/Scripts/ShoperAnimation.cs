using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoperAnimation : MonoBehaviour
{
    public AnimationClipController animationClipController;
    public Animator animator;
    private void Awake()
    {
        animationClipController = FindObjectOfType<AnimationClipController>();
        animator = GetComponent<Animator>();
        animationClipController = Resources.Load<AnimationClipController>("Scriptable/AnimationClip");
    }

    private void PlayAnimation(AnimationClip animationClip)
    {
        string clip = animationClip.name;
        animator.Play(clip);

    }

    public void PlayShopHappy()
    {
        PlayAnimation(animationClipController.ShopHappy);
    }

    public void PlayShopAngry()
    {
        PlayAnimation(animationClipController.ShopAngry);
    }

    public void PlayShopGuide()
    {
        PlayAnimation(animationClipController.ShopGuide);
    }
    public void PlayShopIdle()
    {
        PlayAnimation(animationClipController.ShopGuide);
    }
}
