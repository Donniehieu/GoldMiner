using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOb : MonoBehaviour
{
    public int point;
    public float speed;
    public ShopController shopController;  
    [SerializeField] CharacterAnimation characterAnimation;
    [SerializeField] AnimationClipController animationName;
    [SerializeField] Animator anim;
    private void OnEnable()
    {
        shopController = FindObjectOfType<ShopController>();       
        characterAnimation = FindObjectOfType<CharacterAnimation>();
        animationName = Resources.Load<AnimationClipController>("Scriptable/AnimationClip");
        anim = GetComponent<Animator>();
    }
    private void CheckRockVoucher()
    {
        if (shopController.isRockVoucher == true)
        {
            point += point / 2;
        }
    }

    private void CheckEnergy()
    {
        if (shopController.isEnergy == true)
        {
            characterAnimation.PlayEnergy();
        }
    }

    private void CheckPolish()
    {
        if (shopController.isPolish == true)
        {
            if (gameObject.name == "kimcuong_0(Clone)" || gameObject.name == "mouse2_0(Clone)")
            {
                point += point / 2;
            }
        }
    }
    public void Collision()
    {
        SoundManager.Instance.isBlank = false;
        CheckPolish();
        if (GetComponent<LuckBag>())
        {
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipCongQua);
            GetComponent<LuckBag>().SetRandomItem(shopController.isClover);
        }      
          
      
        if(gameObject.name =="dalon(Clone)" )
        {
            CheckRockVoucher();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetDa);
            characterAnimation.PlayHeavy();
        }
        if( gameObject.name == "danho(Clone)")
        {
            CheckRockVoucher();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetDa);
        }
        if (gameObject.name == "kimcuong_0(Clone)")
        {
            characterAnimation.PlayLight();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetKimCuong);
        }
        if(gameObject.name == "vangnho_0(Clone)")
        {
            characterAnimation.PlayLight();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetVangNho);
        }
        if (gameObject.name == "vangvua_0(Clone)")
        {
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetVangLon);
            anim.Play(animationName.Vangvuadrop.name);
        }
        if (gameObject.name == "vangsieulon_0(Clone)")
        {
            characterAnimation.PlayHeavy();
            SoundManager.Instance.PlayColliderSound(SoundManager.Instance.clipList.clipGetVangLon);
            anim.Play(animationName.Vangsieulondrop.name);
        }
        if (gameObject.name == "tnt_0(Clone)")
        {
            SoundManager.Instance.isBlank = true;
            characterAnimation.PlayLight();
        }
        CheckEnergy();
    }
}
