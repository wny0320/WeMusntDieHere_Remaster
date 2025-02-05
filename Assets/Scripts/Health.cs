using UnityEngine;

public class Health : MonoBehaviour
{
    private int hunger;
    private int thirst;
    private int stress;

    private int maxHunger;
    private int maxThirst;
    private int maxStress;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        hunger = 100;
        thirst = 100;
        stress = 0;

        maxHunger = 100;
        maxThirst = 100;
        maxStress = 100;
    }
    /// <summary>
    /// �ϳ��� HealthData�� �ް� ���� �� ���
    /// </summary>
    /// <param name="_healthType">�ް� ���� HealthData�� Type</param>
    /// <returns>���ϴ� HealthData Value</returns>
    public int GetHealthData(HealthType _healthType)
    {
        switch(_healthType)
        {
            case HealthType.Hunger:
                return hunger;
            case HealthType.Thirst:
                return thirst;
            case HealthType.Stress:
                return stress;
            default:
                return -1;
        }
    }
    /// <summary>
    /// HealthData ���θ� �ް� ���� �� ���
    /// </summary>
    /// <returns>HealthData�� int �迭, hunger, thirst, stress ��</returns>
    public int[] GetHealthDatas()
    {
        int[] healthData = { hunger, thirst, stress };
        return healthData;
    }
    /// <summary>
    /// �ϳ��� HealthData ���� �����ϰ� ���� �� ���
    /// </summary>
    /// <param name="_healthType">�����ϰ� ���� HealthData�� Type</param>
    /// <param name="_value">���� ��</param>
    public void EditHealthData(HealthType _healthType, int _value)
    {
        switch (_healthType)
        {
            case HealthType.Hunger:
                hunger += _value;
                break;
            case HealthType.Thirst:
                thirst += _value;
                break;
            case HealthType.Stress:
                stress += _value;
                break;
            default:
                break;
        }
        MinMaxValueSet();
    }
    /// <summary>
    /// HealData ���θ� ������ �� ���
    /// </summary>
    /// <param name="_values">�����ϰ� ���� HealthData ������ int �迭</param>
    public void EditHealthDatas(int[] _values)
    {
        hunger = _values[0];
        thirst = _values[1];
        stress = _values[2];
        MinMaxValueSet();
    }
    private void MinMaxValueSet()
    {
        if(hunger > maxHunger)
            hunger = maxHunger;
        if(hunger < 0)
            hunger = 0;

        if(thirst > maxThirst)
            thirst = maxThirst;
        if(thirst < 0)
            thirst = 0;

        if(stress > maxStress)
            stress = maxStress;
        if(stress < 0)
            stress = 0;
    }
}
