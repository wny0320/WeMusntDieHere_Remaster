using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    public List<TalentData> talentDataList = new List<TalentData>();
    public List<Item> itemDataList = new List<Item>();
    const string TALENT_DATA_PATH = "TalentData/";
    const string ITEM_DATA_PATH = "ITEM/";
    protected override void Awake()
    {
        base.Awake();
        DataImport();
    }
    private void DataImport()
    {
        talentDataList.Clear();
        TalentData[] talentData = Resources.LoadAll<TalentData>(TALENT_DATA_PATH);
        foreach (TalentData dataItem in talentData)
            talentDataList.Add(dataItem);

        itemDataList.Clear();
        Item[] itemData = Resources.LoadAll<Item>(ITEM_DATA_PATH);
        foreach (Item dataItem in itemData)
            itemDataList.Add(dataItem);
    }
    public string DataToJson(object _obj)
    {
        return JsonConvert.SerializeObject(_obj, Formatting.Indented);
    }

    public T JsonToData<T>(string _jsonObj)
    {
        return JsonConvert.DeserializeObject<T>(_jsonObj);
    }

    public void ExportJsonData<T>(object _obj)
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{typeof(T).Name}.Json");

        File.WriteAllText(jsonPath, DataToJson(_obj));
    }

    public T ImportJsonData<T>()
    {
        // Application.persistentDataPath = C:\Users\사용자이름\AppData\LocalLow\회사이름\게임이름
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{typeof(T).Name}.Json");
        Debug.Log(jsonPath);
        if (File.Exists(jsonPath) == true)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            T jsonObj = JsonToData<T>(jsonFile);
            return jsonObj;
        }

        return default(T);
    }
}
