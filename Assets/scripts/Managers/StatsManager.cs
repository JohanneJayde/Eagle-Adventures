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

public class StatsManager : MonoBehaviour
{

    public UnityEvent onStatUpdate;
/*
 * Singleton logic
 */
    private static StatsManager _instance;

    public static StatsManager Instance
    {
       get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }
    }

    public void UpdateCoins(int coins){
        PlayerManager.Instance.UpdateCoins(GetNewCoinCount(coins));
        onStatUpdate?.Invoke();
    }

    public int GetNewCoinCount(int coins){
        return PlayerManager.Instance.CoinCount += coins;
    }

    public void UpdateExp(int exp){
        PlayerManager.Instance.UpdateExp(exp);

        if(CheckForLevelUp()){
            Debug.Log("Level up time!");
            UpdateLevel();
        }
            Debug.Log("No Level up time!");

        onStatUpdate?.Invoke();
    }

    public void UpdateQuestDone(string questID){
        PlayerManager.Instance.UpdateQuestDone(questID);

    }

    public void UpdateProgress(Quest quest){
        UpdateCoins(quest.CoinRewards);
        UpdateExp(quest.ExpRewards);
        UpdateQuestDone(quest.QuestID);

    }

    public bool CheckForLevelUp(){

        int level = PlayerManager.Instance.Level;
        int totalExp = PlayerManager.Instance.ExpEarned;

        return totalExp >= GameData.PlayerLevels[level + 1];
    }

    public int GetUpdatedLevel(int totalExp){
        int newLevel = 0;

        foreach(var xp in GameData.PlayerLevels){
            if(totalExp >= xp.Value){
                newLevel = xp.Key;
            }
        }

        return newLevel;
    }

    public void UpdateLevel(){
        int newLevel = GetUpdatedLevel(PlayerManager.Instance.ExpEarned);
        Debug.Log("New Level unlcoked");
        PlayerManager.Instance.UpdateLevel(newLevel);
        onStatUpdate?.Invoke();

    }

    public void EmptyCoins(){
        PlayerManager.Instance.UpdateCoins(0);
        onStatUpdate?.Invoke();
    }

    public void UpdateCoinsAndExp(int coins, int exp){
        UpdateCoins(coins);
        UpdateExp(exp);
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
