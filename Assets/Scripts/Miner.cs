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
        // �ʱ� ������ �ӽ÷� 2���� ����� 50% ���� 50%Ȯ���� ȹ�氡��
        talent.AddRandomTalent(2, 50);
    }
}
