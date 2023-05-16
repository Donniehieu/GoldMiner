using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public List<GameObject> listLevel = new List<GameObject>();

    [SerializeField] LevelMapControler levelMapControler;

    [SerializeField] Transform levelSelectTrans;

    private void Reset()
    {
        levelMapControler = GetComponent<LevelMapControler>();
        levelSelectTrans = GameObject.Find("LevelSellect").transform;
    }
    private void Awake()
    {
        InstantiateLevel();
    }
    private void InstantiateLevel()
    {
        if (listLevel.Count > 0) return;
        GameObject orgLevel = Resources.Load<GameObject>("Prefabs/Level");
        for (int i = 0; i < levelMapControler.maxItem; i++)
        {
            GameObject newOb = Instantiate(orgLevel);
            newOb.transform.SetParent(levelSelectTrans);            
            listLevel.Add(newOb);            
        }
        levelMapControler.OnValidateShow(levelMapControler.idPage);
    }

   
}
