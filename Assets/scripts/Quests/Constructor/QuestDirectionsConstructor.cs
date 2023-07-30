using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDirectionsConstructor : MonoBehaviour
{

    public static GameObject GetDirectionsScreen(Quest quest){
        // Quest quest = questScreen.GetComponent<QuestIntroScreen>().Quest;
        // GameObject directionsScreen = GetPrefabScreen(quest);

         return (GameObject)Resources.Load("Prefabs/Quest Screens/Directions/"+ quest.Type+ " Directions")
;
    }

    public static GameObject GetPrefabScreen(Quest quest){
        GameObject screen = Instantiate(
                (GameObject)Resources.Load("Prefabs/Quest Screens/Directions/"+ quest.Type+ " Directions")
                , new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        
        return screen;

    }

}
