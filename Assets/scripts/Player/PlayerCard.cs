using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

/*
 * PlayerCard deals with updating the Player information in the profile screen.
 * It must be updated when a level up occurs or when the player's coin count changes
 * 
 * Dependency(s): 
 * PlayerManager: (Needs to grab the user's stats to display them on card)
 * 
 * Invoke(s): 
 * PlayerProgressManager.UpdatePlayerProgress(): Call RenderCard() when a user's stats are changed
 */

public class PlayerCard : MonoBehaviour
{
    /*
     * This function should be invoked when update events happen
     */
    public void RenderCard()
    {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "Hello, " +  PlayerManager.Instance.Name;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + PlayerManager.Instance.Level.ToString();
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coin Count: " + PlayerManager.Instance.CoinCount.ToString();
    //    SetLevelBar(PlayerManager.Instance.Level);
    }


    // public void SetLevelBar(int level){
    //     Debug.Log(PlayerManager.Instance);
    //     int localExpRange = LevelData.Levels[level + 1] - LevelData.Levels[level];
    //     Debug.Log($"Local XP Range: {localExpRange} ");

    //     float normalizedPlayerExp = 
    //     ((float)(PlayerManager.Instance.ExpEarned - LevelData.Levels[level] ) / (localExpRange));
    //     Debug.Log($"Normalized Player EXP: {normalizedPlayerExp} ");

    //     GameObject innerLevelBar = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;

    //     innerLevelBar.GetComponent<Image>().fillAmount = normalizedPlayerExp;

    // }

    //On Start, it should display the stats the user
    private void Start()
    {
        RenderCard();
    }

}
