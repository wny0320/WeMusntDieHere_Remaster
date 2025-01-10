using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public List<TalentData> talentDataList = new List<TalentData>();
    const string TALENT_DATA_PATH = "TalentData/";
    public void OnAwake()
    {
        TalentDataImport();
    }
    private void TalentDataImport()
    {
        talentDataList.Clear();
        TalentData[] data = Resources.LoadAll<TalentData>(TALENT_DATA_PATH);
        foreach (TalentData dataItem in data)
            talentDataList.Add(dataItem);
    }
}
