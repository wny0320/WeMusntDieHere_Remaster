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
    /// Talent가 추가되고 제거될 때마다 호출
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
    /// TalentManager에 있는 GetRandomTalent를 이용해 Add해주는 함수
    /// </summary>
    /// <param name="_num">얻을 특성의 최대갯수</param>
    /// <param name="_chance">얻게되는 확률, 백분률 0~100%</param>
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
