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
        PlayerManager.Instance.UpdateCoins(coins);
        onStatUpdate?.Invoke();
    }

    public void UpdateExp(int exp){
        PlayerManager.Instance.UpdateExp(exp);

        if(CheckForLevelUp()){
            UpdateLevel();
        }

        onStatUpdate?.Invoke();
    }

    public void UpdateQuestDone(string questID){
        PlayerManager.Instance.UpdateQuestDone(questID);

    }

    public void UpdateProgress(Quest quest){
        PlayerManager.Instance.UpdateCoins(quest.CoinRewards);
        PlayerManager.Instance.UpdateExp(quest.ExpRewards);
        PlayerManager.Instance.UpdateQuestDone(quest.QuestID);

    }

    public bool CheckForLevelUp(){

        int level = PlayerManager.Instance.Level;
        int totalExp = PlayerManager.Instance.ExpEarned;

        return totalExp > GameData.PlayerLevels[level + 1];
    }

    public int GetUpdatedLevel(int totalExp){
        int newLevel = 0;

        foreach(var xp in GameData.PlayerLevels){
            if(totalExp > xp.Value){
                newLevel = xp.Key;
            }
        }

        return newLevel;
    }

    public void UpdateLevel(){
        int newLevel = GetUpdatedLevel(PlayerManager.Instance.ExpEarned);
        PlayerManager.Instance.UpdateLevel(newLevel);
        onStatUpdate?.Invoke();

    }

    public void EmptyCoins(){
        UpdateCoins(0);
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
