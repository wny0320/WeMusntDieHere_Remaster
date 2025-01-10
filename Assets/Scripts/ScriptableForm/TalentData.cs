using UnityEngine;

[CreateAssetMenu(fileName = "TalentData", menuName = "Scriptable Objects/TalentData")]
public class TalentData : ScriptableObject
{
    public string talentName;
    public string talentExplain;
    public HealthType affectType;
    public float affectValue;
}
