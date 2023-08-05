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
    public Button SendScreen;


    public virtual void RenderQuest(Quest quest){
        Quest = quest;
        Directions.text = quest.Directions;

        SendScreen.onClick.AddListener(
            () =>
            {
                HandlePress();
            }
        );


    }

/// <summary>
/// Method that handles the button press
/// </summary>
    public abstract void HandlePress();
    
 
}
