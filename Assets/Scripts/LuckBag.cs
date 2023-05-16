using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckBag : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] LineControl lineController;

    [SerializeField] UIGamePlay uiGamePlay;

    [SerializeField] CharacterAnimation characterAnimation;

    [SerializeField] EffectControler effectControler;
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        lineController = FindObjectOfType<LineControl>();
        uiGamePlay = FindObjectOfType<UIGamePlay>();
        characterAnimation = FindObjectOfType<CharacterAnimation>();
        effectControler = FindObjectOfType<EffectControler>();
    }
    public void SetRandomItem(bool isBuyGlove)
    {
        if( isBuyGlove == true)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                SetMuchCoin(true);
            }
            if (rand == 1)
            {
                SetPower();
            }
            // only spawn energy, more coin
            
        }
        if(isBuyGlove == false)
        {
            // spawn energy, less money, clock, dynamyte
            int rand = 1;  Random.Range(0,4);
            if (rand == 0)
            {
                SetPower();
               
            }
            else if(rand == 1)
            {
                SetMuchCoin(false);
               
            }
            else if (rand == 2)
            {
                SetMoreTime();
               
            }
            else
            {
                SetDynamite();               
            }
        }
    }

    private void SetPower()
    {
        gameManager.shopController.isEnergy=true;        
        characterAnimation.PlayEnergy();
    }

    private void SetMuchCoin(bool clover)
    {
        int rand;
        if (clover == true)
        {
            rand= Random.Range(300, 500);
        }
        else
        {
            rand = Random.Range(100, 200);
        }
        
        uiGamePlay.CurrentScore += rand;
        SoundManager.Instance.PlaySoundFx(SoundManager.Instance.clipList.clipCongTien);
        SoundManager.Instance.effectAudio.loop = false;
        lineController.hook.addScore = rand;
        if (lineController.hook.addScore != 0)
        {
            effectControler.GetScore();
        }
    }

    private void SetMoreTime()
    {
        uiGamePlay.CurrentTime += 10;        
        effectControler.GetTime();        
    }

    private void SetDynamite()
    {
        uiGamePlay.DynamiteCount += 1;
    }
}
