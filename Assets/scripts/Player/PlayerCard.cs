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

    public TMP_Text CurrentLevel;
    public Image LevelBar;
    public TMP_Text CoinCount;
    public TMP_Text Name;
    public TMP_Text Group;

    public Button CanvasButton;

    /*
     * This function should be invoked when update events happen
     */
    public void RenderCard()
    {

        Name.text = "Hello, " + PlayerManager.Instance.Name;
        Group.text = PlayerManager.Instance.Group.ToString();

        CoinCount.text = PlayerManager.Instance.CoinCount.ToString();
        CurrentLevel.text = "Level " + PlayerManager.Instance.Level.ToString();
        SetLevelBar(PlayerManager.Instance.Level);
    }

    public void UpdateCard(){
        CoinCount.text = PlayerManager.Instance.CoinCount.ToString();
        CurrentLevel.text = "Level " + PlayerManager.Instance.Level.ToString();
        SetLevelBar(PlayerManager.Instance.Level);
    }


    public void SetLevelBar(int level){
        Debug.Log(PlayerManager.Instance);
        int localExpRange = GameData.PlayerLevels[level + 1] - GameData.PlayerLevels[level];
        Debug.Log($"Local XP Range: {localExpRange} ");

        float normalizedPlayerExp = 
        ((float)(PlayerManager.Instance.ExpEarned - GameData.PlayerLevels[level] ) / (localExpRange));
        Debug.Log($"Normalized Player EXP: {normalizedPlayerExp} ");

        LevelBar.fillAmount = normalizedPlayerExp;

    }

    public void OpenCanvasCourse(){
        Application.OpenURL("https://canvas.ewu.edu/courses/1675928");
    }

    //On Start, it should display the stats the user
    private void Start()
    {
        RenderCard();
        CanvasButton.onClick.AddListener(
            () => 
            {
                OpenCanvasCourse();
            }
        );
    }

}
