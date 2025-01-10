using UnityEngine;
using System.Collections.Generic;

public class Miner : MonoBehaviour
{
    private string minerName;

    private Health health;
    private Talent talent;

    void Start()
    {
        health = GetComponent<Health>();
        talent = GetComponent<Talent>();
    }

    public void Init()
    {
        health.Init();
        talent.Init();
    }

    public void SetRandomMiner()
    {
        // 초기 설정은 임시로 2개의 재능을 50% 각각 50%확률로 획득가능
        talent.AddRandomTalent(2, 50);
    }
}
