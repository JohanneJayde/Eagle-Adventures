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



    public override void RenderDirections(Quest quest){
        base.RenderDirections(quest);
        Debug.Log(Quest);
        Question.text = Quest.Question;

        SendScreen.onClick.AddListener(
            () => 
            {
                Debug.Log("Hi");
            }
        );

    }

    public override void HandlePress()
    {

        if(CheckAnswer()){
            Status.text = "Correct Answer!";
        }
        else{
            Status.text = "Sorry! That answer was incorrect!";

        }

    }

    public bool CheckAnswer(){

        return Quest.ShortAnswer == QuestionInput.text ? true : false;

    }
    

}
