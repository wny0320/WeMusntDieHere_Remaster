using System.Collections.Generic;
using UnityEngine;

public class MinerManager : Singleton<MinerManager>
{
    List<Miner> minerList;
    GameObject minerPrefab;
    protected override void Awake()
    {
        base.Awake();
        minerList = new List<Miner>();
    }
    public void NewMiner()
    {
        minerList.Add(Instantiate(minerPrefab).GetComponent<Miner>());
    }
}
