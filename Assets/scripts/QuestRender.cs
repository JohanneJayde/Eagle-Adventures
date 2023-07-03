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
         * In order to render the tile correctly, we will use NewPos to store the position of the bottom most child
         * within the overview page. This is so we can position the new tile relative to last child.
         */
        Vector2 NewPos;
        //Get the last child as a Transform component
        Transform child = gameObject.transform.GetChild(gameObject.transform.childCount - 1);
        /*
         * Get the last child's position as a Vector3 object. Because position holds 3 dimensions,
         * we have to get Vector3 but z cord will not be used
         */
        Vector3 childPos = child.transform.position;

        /*
         * Now we must check we are rendering the first Quest. If that is the case, the positioning will be slightly different
         * This is because we coordinates stored in childPos are the top right most. If we are rendering the first quest,
         * then the last child will be the header which is less height than a "QuestTile" prefab. So we need to render it
         * higher than we would if we were rendering after a Quest tile. 
         * 
         * NOTE: in both cases, the x coord is still used due to the header being centered
         */
        //if (gameObject.transform.childCount == 1)
        //{
        //    //NewPos will set the new Tile at a position 300 below the header
        //    NewPos = new(childPos.x, childPos.y - 300);
        //    Debug.Log("Loading first Quest");
        //}

        //else
        //{
        //    //NewPos is set 450 below preceding Quest tile
        //    NewPos = new(childPos.x, childPos.y - 450);
        //}

        Vector3 newpos = content.transform.position;

        /*
         * Now that we have found the correct coordinates for the new tile, we need to load the prefab
         * We do this using Instantiate with the thing we want is the QuestTile that is loaded using
         * Resources.Load. It has it's position set as newPos and it's parent as the overview page
         */
        GameObject questTileTemplate = Instantiate((GameObject)Resources.Load("QuestTile"), new Vector2(newpos.x, newpos.y - 300), new Quaternion(0, 0, 0, 0), content.transform);

        /*
         * After instantiating the tile, populate it's predefined fields with the infomation gleamed from
         * FetchQuestID. Along with this, we also need to make sure that it is ordered in the right fashion
         * using SetSiblingIndex with param of the last child
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
