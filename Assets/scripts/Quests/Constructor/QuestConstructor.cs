using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestConstructor
{

    public static GameObject ConstructQuest(Quest quest, GameObject parent){
        GameObject Tile = QuestTileConstructor.GetTile(quest, parent);
        GameObject IntroScreen = QuestIntroConstructor.GetIntroScreen(quest);
        GameObject DirectionScreen = QuestDirectionsConstructor.GetDirectionsScreen(quest);
        
        Tile.GetComponent<QuestTile>().SetLinkToIntro(IntroScreen);
        IntroScreen.GetComponent<QuestIntroScreen>().SetLinktoDirections(DirectionScreen);

        return Tile;
    }

    public static void ConstructQuests(List<Quest> quests, GameObject parent){

        foreach(var quest in quests){
            ConstructQuest(quest, parent);
        }

    }


}
