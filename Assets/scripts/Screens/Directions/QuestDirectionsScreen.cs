using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class QuestDirectionsScreen : MonoBehaviour
{


    [SerializeField]
    public Quest Quest;
    public TMP_Text Directions;
    public TMP_Text Title;

    public Button SendScreen;


    public virtual void RenderDirections(Quest quest){
        Quest = quest;
        Directions.text = quest.Directions;
        Title.text = quest.Title;

        


    }

/// <summary>
/// Method that handles the button press
/// </summary>
    public abstract void HandlePress();
    
 
}
