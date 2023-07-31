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

    public void HandlePress()
    {
        if(CheckCode()){
            Status.text = "Correct Answer!";
            RewardsScreenConstructor.ChestFoundChainCodeEntry(gameObject);
            Destroy(gameObject);
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
    }


    public bool CheckCode(){
        return CodeField.text == Quest.Code ? true : false;
    }


}
