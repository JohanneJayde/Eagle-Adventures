using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDetailScreen : MonoBehaviour
{

    public GameObject intro;
    public GameObject directions;

    public void RenderQuest(Quest q){
        intro.GetComponent<QuestIntroScreen>().RenderQuest(q);
        directions.GetComponent<QuestDirectionsScreen>().RenderQuest(q);
    }

}
