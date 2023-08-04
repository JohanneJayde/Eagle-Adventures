using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuestIntroScreen : MonoBehaviour
{
    public Quest Quest;
    public TMP_Text Description;
    public TMP_Text Title;
    public Button DirectionsScreenButton;
    public GameObject directions;

    public void RenderQuest(Quest quest){
        Quest = quest;
        Description.text = quest.Description;
        Title.text = quest.Title;
        SetLinktoDirections();
    }

    public void SetLinktoDirections(){

        DirectionsScreenButton.onClick.AddListener
        ( 
        ()=> 
            {
                Debug.Log("creating quest");
                gameObject.SetActive(false);
                directions.SetActive(true); 
            }
        );
    }
    
}
