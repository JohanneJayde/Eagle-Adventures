using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestDetailScreen : MonoBehaviour
{

    public GameObject intro;
    public GameObject directions;
    public TMP_Text Title;
    public Quest Quest;

    public void RenderQuest(Quest q){
        Quest = q;
        Title.text = q.Title;
        intro.GetComponent<QuestIntroScreen>().RenderQuest(q);
        directions.GetComponent<QuestDirectionsScreen>().RenderQuest(q);
    }
    
    public void ResetScreen(){
        intro.SetActive(true);
        directions.SetActive(false);
    }

}
