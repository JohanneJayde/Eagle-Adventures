using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIntroConstructor : MonoBehaviour
{

    public static GameObject GetIntroScreen(Quest quest){
    
        GameObject screen = 
        //Instantiate(
        Resources.Load("Prefabs/Quest Screens/Intro/"+ quest.Type+ " Intro")
       // , new Vector2(0, 0), new Quaternion(0, 0, 0, 0)
       // ) 
        as GameObject;
        screen.GetComponent<QuestIntroScreen>().RenderQuest(quest);

        return screen;

    }

    // public static GameObject LinkToDirectionsScreen(GameObject screen){
        
    // }


}

