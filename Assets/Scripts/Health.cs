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
        hunger = 0;
        thirst = 0;
        stress = 0;

        maxHunger = 100;
        maxThirst = 100;
        maxStress = 100;
    }
    /// <summary>
    /// 하나의 HealthData를 받고 싶을 때 사용
    /// </summary>
    /// <param name="_healthType">받고 싶은 HealthData의 Type</param>
    /// <returns>원하는 HealthData Value</returns>
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
    /// HealthData 전부를 받고 싶을 때 사용
    /// </summary>
    /// <returns>HealthData의 int 배열</returns>
    public int[] GetHealthDatas()
    {
        int[] healthData = { hunger, thirst, stress };
        return healthData;
    }
    /// <summary>
    /// 하나의 HealthData 값만 수정하고 싶을 때 사용
    /// </summary>
    /// <param name="_healthType">수정하고 싶은 HealthData의 Type</param>
    /// <param name="_value">수정할 값</param>
    public void EditHealthData(HealthType _healthType, int _value)
    {
        switch (_healthType)
        {
            case HealthType.Hunger:
                hunger = _value;
                break;
            case HealthType.Thirst:
                thirst = _value;
                break;
            case HealthType.Stress:
                stress = _value;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// HealData 전부를 수정할 때 사용
    /// </summary>
    /// <param name="_values">변경하고 싶은 HealthData 값들의 int 배열</param>
    public void EditHealthDatas(int[] _values)
    {
        hunger = _values[0];
        thirst = _values[1];
        stress = _values[2];
    }
}
