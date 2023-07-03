using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static QuestManager;

/*
 * QuestRender handles rendering a set or individual Quests on the app.
 */

public class QuestRender : MonoBehaviour
{
    /*
     * QuestDetailsScreen references the screen where individual Quest info will
     * be displayed
     */

    public GameObject QuestDetailsScreen;
    public GameObject content;

    // On start, RenderAllQuests will render the quests in the Quest Overview screen
    void Start()
    {
        RenderAllQuests();
    }

    /*
     * RenderQuest takes in a string that represents a Quest ID. It will then use FetchQuestInfo to get that quest's info
     * Using that info, a new Prefab of the "QuestTile" asset will be created and displayed on the overview page
     */
    public void RenderQuest(string QID)
    {
        //Get the quest data based on the QID
        Quest q = QuestManager.Instance.FetchQuestInfo(QID);


        /*
         * Now that we have found the correct coordinates for the new tile, we need to load the prefab
         * We do this using Instantiate with the thing we want is the QuestTile that is loaded using
         * Resources.Load. Because we have content size fitter on the scroll area, we need not worry about the
         * position of where we place the tile, only that it's parent is the content container
         */
        GameObject questTileTemplate = Instantiate((GameObject)Resources.Load("QuestTile"), new Vector2(0,0), new Quaternion(0, 0, 0, 0), content.transform);

        /*
         * After instantiating the tile, populate it's predefined fields with the infomation gleamed from
         * FetchQuestID. Along with this, we also need to make sure that it is ordered in the right fashion
         * using SetSiblingIndex with param of the last child
         * 
         * THIS SECTION COULD BE ADDED TO AN EXTERNAL SCRIPT AND ATTCHED TO THE PREFAB OF QUEST TILE
         */
        questTileTemplate.transform.GetChild(0).GetComponent<TMP_Text>().text = q.Title;
        questTileTemplate.transform.GetChild(1).GetComponent<TMP_Text>().text = q.ShortDescription;
        questTileTemplate.transform.GetChild(2).GetComponent<TMP_Text>().text = q.CoinsReward.ToString();
        questTileTemplate.transform.GetChild(3).GetComponent<TMP_Text>().text = q.LevelRequirement.ToString();
        questTileTemplate.transform.SetSiblingIndex(content.transform.childCount - 1);

        /*
         * Clicking the quest tile should bring you to a page that contains the full details of the quest
         * and the way to actually do the quest. The tiles button component has an onClick event added to it.
         * OpenQuestDetails takes in the found Quest and is used to render more on the details page
         */


        questTileTemplate.GetComponent<Button>().onClick.AddListener(() => { OpenQuestDetailsScreen(q); });
        questTileTemplate.name = q.QuestID;
    }
    /*
     * Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full information
     * This is done by first setting the details script's Quest Property to the Quest that we want to render info for.
     * Then call RenderDetails to render the quest info on the screen and swap to the screen to show the details.
     */

    public void OpenQuestDetailsScreen(Quest quest)
    {

       QuestDetailsScreen.GetComponent<QuestDetailsRenderer>().Quest = quest;
       QuestDetailsScreen.GetComponent<QuestDetailsRenderer>().RenderDetails();
       gameObject.SetActive(false);
       QuestDetailsScreen.SetActive(true);
    }

    /*
     * RenderAllQuests renders all the quests by simply getting the all the quests from QuestManager and
     * using foreach loop with RenderQuest.
     */
    public void RenderAllQuests()
    {
        foreach(Quest quest in QuestManager.Instance.Quests)
        {
            RenderQuest(quest.QuestID);
            Debug.Log(quest.QuestID + " has been rendered");
        }
    }

}
