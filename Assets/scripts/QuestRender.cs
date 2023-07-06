using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * QuestRender handles rendering a set or individual Quests on the app.
 */

public class QuestRender : MonoBehaviour
{
    /*
     * QuestDetailsScreen references the screen where individual Quest info will
     * be displayed
     */

    public GameObject content;

    public List<GameObject> QuestTiles = new List<GameObject>();

    /*
     * RenderQuest takes in a string that represents a Quest ID. It will then use FetchQuestInfo to get that quest's info
     * Using that info, a new Prefab of the "QuestTile" asset will be created and displayed on the overview page
     */


    /*
     * RenderAllQuests renders all the quests by simply getting the all the quests from QuestManager and
     * using foreach loop with RenderQuest.
     */
    public void RenderAllQuests()
    {
        foreach (GameObject quest in QuestManager.Instance.QuestTiles)
        {
            quest.transform.SetParent(content.transform);
            quest.transform.SetSiblingIndex(content.transform.childCount - 1);

            QuestTiles.Add(quest);

        }
    }


    // On start, RenderAllQuests will render the quests in the Quest Overview screen
    void Start()
    {
        RenderAllQuests();
    }

    //public void updateTiles()
    //{
    //    foreach (GameObject quest in QuestTiles)
    //    {

    //        quest.GetComponent<QuestTileRender>().Render();
    //    }
    //}

}