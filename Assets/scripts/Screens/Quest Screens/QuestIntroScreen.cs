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

    public void RenderQuest(Quest quest){
        Quest = quest;
        Description.text = quest.Description;
        Title.text = quest.Title;
    }

    public void SetLinktoDirections(GameObject directions){

        DirectionsScreenButton.onClick.AddListener
        ( 
        ()=> 
            {
                Debug.Log("creating quest");

                directions.SetActive(true); 
                Destroy(gameObject);
            }
        );
    }
    
}
