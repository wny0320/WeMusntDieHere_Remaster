using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Miner : MonoBehaviour
{
    public Health health;
    public Talent talent;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        health = GetComponent<Health>();
        talent = GetComponent<Talent>();

        health.Init();
        talent.Init();
    }

    public void SetRandomMiner()
    {
        // 초기 설정은 임시로 2개의 재능을 50% 각각 50%확률로 획득가능
        talent.AddRandomTalent(2, 50);
    }

}
