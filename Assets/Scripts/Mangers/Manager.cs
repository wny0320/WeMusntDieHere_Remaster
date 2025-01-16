using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get { Init(); return instance; } }
    private static Manager instance;
    #region Managers
    MinerManager _miner = new MinerManager();
    TalentManager _talent = new TalentManager();
    HealthManager _health = new HealthManager();
    DataManager _data = new DataManager();
    ChoiceManager _choice = new ChoiceManager();
    public static MinerManager Miner { get { return instance._miner; } }
    public static TalentManager Talent { get { return instance._talent; } }
    public static HealthManager Health { get { return instance._health; } }
    public static DataManager Data { get { return instance._data; } }
    public static ChoiceManager Choice { get { return instance._choice; } }
    #endregion
    private void Awake()
    {
        Init();
        Data.OnAwake();
        Application.targetFrameRate = 60;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static void Init()
    {
        if (instance == null)
        {
            instance = FindFirstObjectByType<Manager>();
            if (Instance != null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<Manager>();
                go.name = typeof(Manager).Name;
                DontDestroyOnLoad(go);
            }
        }
    }
}
