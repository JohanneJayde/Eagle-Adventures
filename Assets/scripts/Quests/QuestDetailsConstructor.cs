using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDetailsConstructor : MonoBehaviour
{

    public static GameObject getQuestScreen(Quest quest){
    
                GameObject screen = Instantiate(
                    (GameObject)Resources.Load("Prefabs/Quest Screens/Intro/"+ quest.Type+ " Intro")
                    , new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                return ConstructIntroScreen(quest, screen);

    }

    public static GameObject ConstructIntroScreen(Quest quest, GameObject screen){
        screen.GetComponent<QuestIntroScreen>().RenderQuest(quest);
       // LinkToDirectionsScreen(screen);

       return screen;
    }

    // public static GameObject LinkToDirectionsScreen(GameObject screen){
        
    // }


}

