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
    public string DataToJson(Object _obj)
    {
        return JsonConvert.SerializeObject(_obj);
    }

    public T JsonToData<T>(string _jsonObj)
    {
        return JsonConvert.DeserializeObject<T>(_jsonObj);
    }

    public void ExportJsonData(string _jsonObj)
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{nameof(_jsonObj)}.Json");

        File.WriteAllText(jsonPath, _jsonObj);
    }

    public T ImportJsonData<T>(string _jsonName)
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{nameof(_jsonName)}.Json");
        if (File.Exists(jsonPath) == true)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            T jsonObj = JsonToData<T>(jsonFile);
            return jsonObj;
        }
        return default(T);
    }
}
