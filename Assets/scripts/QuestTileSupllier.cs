using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.UI;



/*
 * Reasoning: If we are to have multiple places where Quest tiles are needed, then we should have a way
 * to give them a set of quests that they can filter and also will update when it needs to.
 *
 * Proprosed Flow:
 * This script is attached to any screen that needs to render a list of quests.
 * It will clone a list of quest Tiles and 
 *
 */
public class QuestTileSupllier : MonoBehaviour
{

    public GameObject QuestScreen;

    public GameObject CreateTile(Quest quest)
    {
        GameObject QuestTile = Instantiate((GameObject)Resources.Load("Prefabs/QuestTile"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        QuestTile.GetComponent<QuestTile>().Quest = quest;
        QuestTile.GetComponent<QuestTile>().Render();

        ApplyEvents(QuestTile);

        return QuestTile;
    }

    public void ApplyEvents(GameObject tile){
        tile.GetComponent<Button>().onClick.AddListener(() => RenderDetails(tile.GetComponent<QuestTile>().Quest));
    }

    public List<GameObject> CreateTiles(IEnumerable<Quest> Quests)
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in Quests)
        {
          
            QTiles.Add(CreateTile(quest));

        }

        return QTiles;
    }


    public List<GameObject> CreateAllTiles()
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in QuestManager.Instance.Quests)
        {
          
            QTiles.Add(CreateTile(quest));

        }

        return QTiles;
    }

    /*
    * Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full information
    * This is done by first setting the details script's Quest Property to the Quest that we want to render info for.
    * Then call RenderDetails to render the quest info on the screen and swap to the screen to show the details.
    */
    public void RenderDetails(Quest quest)
    {

        QuestScreen.GetComponent<QuestScreen>().SetScreenDetails(quest);
      //  QuestScreen.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => { Unlock(); });
        QuestScreen.SetActive(true);
    }

}
