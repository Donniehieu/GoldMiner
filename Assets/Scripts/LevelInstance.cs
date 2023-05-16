using System.IO;
using UnityEngine;
public class LevelInstance : MonoBehaviour
{
    [SerializeField] Transform transLevel;

    public ListItem listItem = new ListItem();

    [SerializeField] UIGamePlay uiGamePlay;

    [SerializeField] ShopController shopController;

    [SerializeField] GameObject hook;


    public string pathFile;
    public string fileName;
    string data;
    private void Awake()
    {
        pathFile = Application.persistentDataPath; 
    }
    private void Reset()
    {
        transLevel = transform;
        uiGamePlay = FindObjectOfType<UIGamePlay>();
        shopController = FindObjectOfType<ShopController>();
    }

   
    public void LoadMap(int _idMap)
    {
        ClearMap();        
        TextAsset file = Resources.Load( "Maps/"+ _idMap) as TextAsset;
        string path =file.text;
        listItem = JsonUtility.FromJson<ListItem>(path);        
        for (int i = 0; i < listItem.ItemsMap.Count; i++)
        {
            Item listItemInstance = listItem.ItemsMap[i];
            GameObject newOb = InstantiateOb(listItemInstance.nameItems);
            newOb.transform.SetParent(transLevel);
            newOb.transform.position = listItemInstance.pos;
            newOb.transform.rotation = Quaternion.identity;
            newOb.GetComponent<ItemOb>().point = listItemInstance.Score;             
        }
        uiGamePlay.TargetScore = listItem.ItemsMap[listItem.ItemsMap.Count-1].TargetScore;
        uiGamePlay.CurrentScore = uiGamePlay.lastScore;
        if (uiGamePlay.CurrentScore == 0)
        {    
            uiGamePlay.CurrentScore = listItem.ItemsMap[listItem.ItemsMap.Count - 1].GetScore;
        }
        GameManager.Instance.ChangeBackGround(_idMap);
    }

    private GameObject InstantiateOb(string nameOb)
    {
        GameObject ob = Resources.Load<GameObject>("Prefabs/" + nameOb);
        GameObject newOb = Instantiate(ob);
        return newOb;
    } 
    public void SaveData()
    {
        listItem.ItemsMap.Clear();
        pathFile = Application.persistentDataPath;              
        for (int i = 0; i < transLevel.childCount; i++)            
        { 
            Item item = new Item();            
            string nameItem = transLevel.GetChild(i).gameObject.name;
            int startIndex= nameItem.IndexOf("(Clone)");
            item.nameItems = nameItem.Remove(startIndex,7);
            item.pos = transLevel.GetChild(i).gameObject.transform.position;
            item.Score = transLevel.GetChild(i).gameObject.GetComponent<ItemOb>().point;
            item.TargetScore = uiGamePlay.TargetScore;
            listItem.ItemsMap.Add(item);
            item.GetScore = transLevel.GetChild(i).gameObject.GetComponent<ItemOb>().point;
        }        
         string data = JsonUtility.ToJson(listItem);
         string path = Path.Combine(pathFile, fileName);
         File.WriteAllText(path, data);
    }
    public void ClearMap()
    {
        for (int i = 0; i < transLevel.childCount; i++)
        {
            Destroy(transLevel.GetChild(i).gameObject);
        }
        if (hook.GetComponentInChildren<ItemOb>())
        {
            Destroy(hook.GetComponentInChildren<ItemOb>().gameObject);
        }
    }
}
