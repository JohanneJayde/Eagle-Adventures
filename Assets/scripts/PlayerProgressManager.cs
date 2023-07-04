using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TODO: This is going to be used to track player progress
 */

public class PlayerProgressManager : MonoBehaviour
{


    delegate void UpdateHUD();

    Dictionary<int, int> LevelSteps = new Dictionary<int, int>();
 
/*
 * Singleton logic
 */
    private static PlayerProgressManager _instance;

    public static PlayerProgressManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }

    public void UpdateProgress(Quest quest)
    {

        PlayerManager.Instance.ExpEarned += quest.ExpEarned;
        PlayerManager.Instance.CoinCount += quest.CoinsReward;
        PlayerManager.Instance.PlayerProgress[quest.QuestID] = true;
        CheckLevel(PlayerManager.Instance.ExpEarned);
        Debug.Log(PlayerManager.Instance);

        PlayerManager.Instance.SavePlayerInfo();

        Debug.Log("Player Info Updated");

    }

    public void CheckLevel(int totalXP)
    {
        if(totalXP >= LevelSteps[PlayerManager.Instance.Level + 1])
        {
            PlayerManager.Instance.Level++;
            Debug.Log("LEVEL UP!");
        }
        else
        {
            Debug.Log("Not yet!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelSteps.Add(1, 50);
        LevelSteps.Add(2, 150);
        LevelSteps.Add(3, 300);
        LevelSteps.Add(4, 600);




    }


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }
}
