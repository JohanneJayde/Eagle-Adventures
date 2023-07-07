using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class RewardsPopUp : MonoBehaviour
{
 
    public GameObject modal;

    public void PopUp(Quest quest){
        modal.SetActive(true);
        modal.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coin Rewards: +" + quest.CoinsReward.ToString();
        modal.transform.GetChild(3).GetComponent<TMP_Text>().text = "EXP Rewards: +" + quest.ExpEarned.ToString();

    }

    void Start(){
        modal = gameObject.transform.GetChild(0).gameObject;
        gameObject.transform.GetComponent<Button>().onClick.AddListener(() => {
            gameObject.SetActive(false);
            modal.SetActive(false);});

    }


}
