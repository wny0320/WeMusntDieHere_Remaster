using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TalentManager : Singleton<TalentManager>
{
    /// <summary>
    /// Ư������ ������� ���� ������ ���ʽ��� ����ϴ� �Լ�
    /// </summary>
    /// <param name="_talents">������ ������ �ִ� Ư������ ����Ʈ</param>
    /// <returns>������ Ư�� ���ʽ� ��ġ</returns>
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
    /// ������ Ư���� ��� �Լ�, �ִ� 1�������� �⺻�̸� �μ������� Ȯ���� ������ ������ �� ����
    /// </summary>
    /// <param name="_num">���� Ư���� �ִ밹��</param>
    /// <param name="_chance">��ԵǴ� Ȯ��, ��з� 0~100%</param>
    /// <returns>�������� ���� Ư������ ������ ����Ʈ</returns>
    public List<TalentData> GetRandomTalents(int _num = 1, int _chance = 100)
    {
        List<TalentData> talentList = DataManager.Instance.talentDataList;
        List<TalentData> randomTalentList = new List<TalentData>();
        int talentNum = talentList.Count;
        for (int i = 0; i < _num; i++)
        {
            if(Random.Range(0f, 1f) < (100 - _chance) / 100) // Ȯ������ ���� ��� ȹ�� ����
                continue;
            while(true)
            {
                int targetIndex = Random.Range(0, talentNum);
                // �׽�Ʈ �ܰ迡�� talent�� ������ �����ϴ� �������� ���� ��� ���ѷ��� ������
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
