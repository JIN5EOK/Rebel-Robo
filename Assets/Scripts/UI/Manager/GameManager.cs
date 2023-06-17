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

    public int heroIndex = 0;
    public int hammerIndex;



    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
