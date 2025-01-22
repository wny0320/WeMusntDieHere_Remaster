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
        // �ʱ� ������ �ӽ÷� 2���� ����� 50% ���� 50%Ȯ���� ȹ�氡��
        talent.AddRandomTalent(2, 50);
    }

}
