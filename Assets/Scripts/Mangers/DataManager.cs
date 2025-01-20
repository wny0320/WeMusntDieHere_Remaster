using UnityEngine;
using System.Collections.Generic;

public class DataManager : Singleton<DataManager>
{
    public List<TalentData> talentDataList = new List<TalentData>();
    public List<Item> itemDataList = new List<Item>();
    const string TALENT_DATA_PATH = "TalentData/";
    const string ITEM_DATA_PATH = "ITEM/";
    protected override void Awake()
    {
        base.Awake();
        TalentDataImport();
    }
    private void TalentDataImport()
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
}
