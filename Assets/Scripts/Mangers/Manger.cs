using UnityEngine;

public class Manger : MonoBehaviour
{
    // ΩÃ±€≈Ê
    public static Manger Instance { get { Init(); return instance; } }
    private static Manger instance;
    #region Managers
    MinerManager _miner = new MinerManager();
    public static MinerManager Miner { get { return instance._miner; } }
    #endregion
    private void Awake()
    {
        Init();
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
            instance = FindFirstObjectByType<Manger>();
            if (Instance != null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<Manger>();
                go.name = typeof(Manger).Name;
                DontDestroyOnLoad(go);
            }
        }
    }
}
