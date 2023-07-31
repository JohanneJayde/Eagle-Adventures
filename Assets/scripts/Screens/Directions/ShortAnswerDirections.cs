using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ShortAnswerDirections : QuestDirectionsScreen
{

    public TMP_InputField QuestionInput;
    public TMP_Text Status;
    public TMP_Text Question;

    public override void RenderDirections(Quest quest){
        base.RenderDirections(quest);
        Question.text = quest.Question;
    }
    

}
