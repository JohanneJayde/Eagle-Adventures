using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEntry : MonoBehaviour
{

    public Quest Quest;
    public TMP_InputField CodeField;
    public Button EnterCode;
    public TMP_Text Status;
    public Button BackButton;
    public GameObject DirectionScreen;

    public void HandlePress()
    {
       if(CheckCode()){
            Status.text = "Correct Answer!";
            RewardsScreenConstructor.ChestFoundChainCodeEntry(gameObject);
            Destroy(gameObject);
            Destroy(DirectionScreen);
        }
        else{
            Status.text = "Sorry! That answer was incorrect!";
        }
    } 

    public void BackToDirections(){
        Destroy(gameObject);
    }

    public void SetCode(Quest quest){
        Quest = quest;
        Debug.Log(Quest);

        if(CheckCompeted()){
            EnterCode.enabled = false;
            CodeField.enabled = false;
            CodeField.text = Quest.Code;
        }

    }

    public bool CheckCompeted(){
        return PlayerManager.Instance.PlayerProgress[Quest.QuestID] ? true : false;
    }


    public bool CheckCode(){
        return CodeField.text == Quest.Code ? true : false;
    }


}
