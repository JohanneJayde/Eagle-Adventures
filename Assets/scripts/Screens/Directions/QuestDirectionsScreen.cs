using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class QuestDirectionsScreen : MonoBehaviour
{

    public Button SendScreen;
    public TMP_Text Directions;
    public TMP_Text Title;

    public virtual void RenderDirections(Quest quest){
        Directions.text = quest.Directions;
        Title.text = quest.Title;
    }
    
 
}
