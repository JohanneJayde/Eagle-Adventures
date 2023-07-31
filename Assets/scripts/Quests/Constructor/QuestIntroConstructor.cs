using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIntroConstructor : MonoBehaviour
{

    public static GameObject GetIntroScreen(Quest quest){
    
        GameObject screen = Resources.Load("Prefabs/Quest Screens/Intro/"+ quest.Type+ " Intro") as GameObject;

        return screen;

    }

    

    public static GameObject SetIntroScreen(GameObject tile){
        
                Quest questToRender = tile.GetComponent<QuestTile>().Quest;

                GameObject IntroScreen = Instantiate(QuestIntroConstructor.GetIntroScreen(questToRender), tile.transform.root, false);
                SetInfo(questToRender, IntroScreen);
                IntroScreen.SetActive(true);

                return IntroScreen;

    }

    public static void SetInfo(Quest quest, GameObject screen){
        screen.GetComponent<QuestIntroScreen>().RenderQuest(quest);
        screen.name = quest.Title + " Intro";
    }


}

