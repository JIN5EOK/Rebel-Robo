using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int chapterNumber = 1;
    public int stageNumber;
    public int coin = 100;


    public bool stageMenuOn;

    public int clearedStage = 0;

    public static GameManager Instance;
    SaveManager saveManager;

    public int weaphonIndex;
    public int hammerIndex;
    public int[] ingameTower = { 1, 2, 3, 4 };
    public int[] ingameSkill = { 1, 2, 3 };
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
