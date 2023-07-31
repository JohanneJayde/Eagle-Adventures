using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDirectionsConstructor : MonoBehaviour
{

    public static GameObject GetDirectionsScreen(Quest quest){
    
        GameObject screen = Resources.Load("Prefabs/Quest Screens/Directions/"+ quest.Type + " Directions") as GameObject;
        
        return screen;

    }

    public static GameObject SetDirectionsScreen(GameObject tile){

            Quest questToRender = tile.GetComponent<QuestTile>().Quest;

            GameObject DirectionScreen = Instantiate(QuestDirectionsConstructor.GetDirectionsScreen(questToRender), tile.transform.root, false);
            SetInfo(questToRender, DirectionScreen);
            DirectionScreen.SetActive(false);

                DirectionScreen.GetComponent<QuestDirectionsScreen>().SendScreen.onClick.AddListener(
                  () => { DirectionScreen.GetComponent<QuestDirectionsScreen>().HandlePress();}
                );

            return DirectionScreen;

    }

    public static void SetInfo(Quest quest, GameObject screen){
        screen.GetComponent<QuestDirectionsScreen>().RenderDirections(quest);
        screen.name = quest.Title + " Directions";

    }

}
