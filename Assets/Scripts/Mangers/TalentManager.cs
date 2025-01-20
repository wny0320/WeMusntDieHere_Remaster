using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TalentManager : Singleton<TalentManager>
{
    /// <summary>
    /// 특성들을 기반으로 얻은 각각의 보너스를 계산하는 함수
    /// </summary>
    /// <param name="_talents">유닛이 가지고 있는 특성들의 리스트</param>
    /// <returns>각각의 특성 보너스 수치</returns>
    public float[] CalculateAdvantages(List<TalentData> _talents)
    {
        float[] values = new float[3];
        for(int i = 0;  i < _talents.Count; i++)
        {
            int targetIndex = (int)_talents[i].affectType;
            values[targetIndex] += _talents[i].affectValue;
        }
        return values;
    }
    /// <summary>
    /// 무작위 특성을 얻는 함수, 최대 1개까지가 기본이며 인수값으로 확률과 갯수를 조정할 수 있음
    /// </summary>
    /// <param name="_num">얻을 특성의 최대갯수</param>
    /// <param name="_chance">얻게되는 확률, 백분률 0~100%</param>
    /// <returns>랜덤으로 뽑은 특성들의 데이터 리스트</returns>
    public List<TalentData> GetRandomTalents(int _num = 1, int _chance = 100)
    {
        List<TalentData> talentList = DataManager.Instance.talentDataList;
        List<TalentData> randomTalentList = new List<TalentData>();
        int talentNum = talentList.Count;
        for (int i = 0; i < _num; i++)
        {
            if(Random.Range(0f, 1f) < (100 - _chance) / 100) // 확률보다 낮은 경우 획득 실패
                continue;
            while(true)
            {
                int targetIndex = Random.Range(0, talentNum);
                // 테스트 단계에서 talent의 갯수가 얻어야하는 갯수보다 적은 경우 무한루프 방지용
                if (randomTalentList.Contains(talentList[targetIndex]) && talentNum >= _num)
                    continue;
                else
                    randomTalentList.Add(talentList[targetIndex]);
                    break;
            }
        }
        return randomTalentList;
    }
}
