using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public List<Slider> healthUIList;
    [SerializeField]
    private Miner targetMiner;

    private void Start()
    {
        TestHealthChange();
    }
    private void Update()
    {
        SyncHealth();
    }
    private void SyncHealth()
    {
        int[] healthDatas = targetMiner.health.GetHealthDatas();
        healthUIList[0].value = healthDatas[0];
        healthUIList[1].value = healthDatas[1];
        healthUIList[2].value = healthDatas[2];
    }
    private void TestHealthChange()
    {
        targetMiner.health.EditHealthData(HealthType.Hunger, -50);
    }
}
