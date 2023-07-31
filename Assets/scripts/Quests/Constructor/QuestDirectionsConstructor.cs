using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDirectionsConstructor : MonoBehaviour
{

    public static GameObject GetDirectionsScreen(Quest quest){
    
        GameObject screen = Resources.Load("Prefabs/Quest Screens/Directions/"+ quest.Type + " Directions") as GameObject;

        screen.GetComponent<QuestDirectionsScreen>().RenderDirections(quest);

        return screen;

    }

    public static GameObject SetDirectionsScreen(GameObject tile){

            Quest questToRender = tile.GetComponent<QuestTile>().Quest;

            GameObject DirectionScreen = Instantiate(QuestDirectionsConstructor.GetDirectionsScreen(questToRender), tile.transform.root, false);
            DirectionScreen.name = questToRender.Title + " Directions";
            DirectionScreen.SetActive(false);

            return DirectionScreen;

    }

}
