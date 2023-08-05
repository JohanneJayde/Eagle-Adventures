using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShortAnswerDirections : QuestDirectionsScreen
{

    public TMP_InputField QuestionInput;
    public TMP_Text Status;
    public TMP_Text Question;



    public override void RenderQuest(Quest quest){

        base.RenderQuest(quest);
        Debug.Log(Quest);
        Question.text = Quest.Question;

        if(PlayerManager.Instance.PlayerProgress[quest.QuestID]){
            SendScreen.enabled = false;
            QuestionInput.enabled = false;
            QuestionInput.text = quest.ShortAnswer;
        }
 
    }

    public override void HandlePress()
    {
        if(CheckAnswer()){
            Status.text = "Correct Answer!";
            RewardsScreenConstructor.ChestFoundChain(Quest, gameObject);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else{
            Status.text = "Sorry! That answer was incorrect!";

        }

    }

    public bool CheckAnswer(){

        return Quest.ShortAnswer == QuestionInput.text ? true : false;

    }
    

}
