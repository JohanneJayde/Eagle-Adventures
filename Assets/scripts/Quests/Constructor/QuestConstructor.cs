using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestConstructor : MonoBehaviour
{

    public static GameObject ConstructQuest(Quest quest, GameObject parent, GameObject highestScreen){
        GameObject Tile = QuestTileConstructor.GetTile(quest, parent);
        
        Tile.GetComponent<QuestTile>().StartButton.onClick.AddListener(
            () =>
            {
                highestScreen.SetActive(false);
                GameObject IntroScreen = QuestIntroConstructor.SetIntroScreen(Tile);
                GameObject DirectionScreen = QuestDirectionsConstructor.SetDirectionsScreen(Tile);

                IntroScreen.GetComponent<QuestIntroScreen>().SetLinktoDirections(DirectionScreen);

            }
            );

        return Tile;
    }

    public static void ConstructQuests(List<Quest> quests, GameObject parent, GameObject highestScreen){

        foreach(var quest in quests){
            ConstructQuest(quest, parent, highestScreen);
        }

    }


}
