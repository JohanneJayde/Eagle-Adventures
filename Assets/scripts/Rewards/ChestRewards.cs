using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestRewards : MonoBehaviour
{

    public Quest Quest;
    public Button ReturnToProfileButton;
    public TMP_Text Coins;
    public TMP_Text Exp;

    public void ShowRewards(Quest quest){
        Coins.text = quest.CoinRewards.ToString() + "G";
        Exp.text = quest.ExpRewards.ToString() + " XP";
        StatsManager.Instance.UpdateProgress(quest);
    }

    public void ReturnToProfilePage(){
        ReturnToProfileButton.onClick.AddListener(
            () =>
            {
                Destroy(gameObject);
            }
        );
    }

}
