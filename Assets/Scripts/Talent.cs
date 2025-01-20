using UnityEngine;
using System.Collections.Generic;


public class Talent : MonoBehaviour
{
    private List<TalentData> talents = new List<TalentData> ();

    private float hungerAdvantage;
    private float thirstAdvantage;
    private float stressAdvantage;

    private void Awake()
    {
        Init();
    }
    /// <summary>
    /// Talent�� �߰��ǰ� ���ŵ� ������ ȣ��
    /// </summary>
    private void CalculateAdvantages()
    {
        float[] advantages = TalentManager.Instance.CalculateAdvantages(talents);
        hungerAdvantage = advantages[(int)HealthType.Hunger];
        thirstAdvantage = advantages[(int)HealthType.Thirst];
        stressAdvantage = advantages[(int)HealthType.Stress];
    }
    public void Init()
    {
        talents.Clear();

        hungerAdvantage = 0;
        thirstAdvantage = 0;
        stressAdvantage = 0;
    }
    public float[] GetAdvantages()
    {
        float[] advantages = { hungerAdvantage, thirstAdvantage, stressAdvantage };
        return advantages;
    }
    public void AddTalent(TalentData _talent)
    {
        talents.Add(_talent);
        CalculateAdvantages();
    }
    public void RemoveTalent(TalentData _talent)
    {
        if (talents.Count < 0)
            Debug.Log("Unit's Talent Is Empty");
        else
        {
            if (talents.Contains(_talent))
                talents.Remove(_talent);
            else
                Debug.Log("Unit Doesn't Have Talent");
        }
        CalculateAdvantages();
    }
    /// <summary>
    /// TalentManager�� �ִ� GetRandomTalent�� �̿��� Add���ִ� �Լ�
    /// </summary>
    /// <param name="_num">���� Ư���� �ִ밹��</param>
    /// <param name="_chance">��ԵǴ� Ȯ��, ��з� 0~100%</param>
    public void AddRandomTalent(int _num = 1, int _chance = 100)
    {
        List<TalentData> randomTalentList = TalentManager.Instance.GetRandomTalents(_num, _chance);
        int cnt = randomTalentList.Count;
        for (int i = 0; i < cnt; i++)
        {
            AddTalent(randomTalentList[i]);
        }
    }
}
