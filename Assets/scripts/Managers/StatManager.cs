using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * TODO: This is going to be used to track player progress
 *
 * Due to how the program has been evolving, this script may be removed in favor of directly hooking it up
 * it will depend on how much the PlayerManager script changes when dynamic quests are added.
 */

public class StatManager : MonoBehaviour
{

    public UnityEvent onStatUpdate;
/*
 * Singleton logic
 */
    private static StatManager _instance;

    public static StatManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }

    public void UpdateCoins(int coins){

    }

    public void UpadteExp(int extp){

    }

    public void UpdateQuestDone(string questID){

    }

    public void UpateLevel(int exp){

    }

    public void UpdateProgress(Quest quest){
        PlayerManager.Instance.UpdateCoins(quest.CoinRewards);
        PlayerManager.Instance.UpdateExp(quest.ExpRewards);
        PlayerManager.Instance.UpdateQuestDone(quest.QuestID);

    }

    public void UpdateCoinsAndExp(int coins, int exp){

    }

    // Start is called before the first frame update
    void Start()
    {

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
