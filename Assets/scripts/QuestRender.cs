using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static QuestManager;

public class QuestRender : MonoBehaviour
{

    public GameObject homeScreen;

    // Start is called before the first frame update
    void Start()
    {
        RenderAllQuests(QuestManager.Instance);
    }

    public void RenderQuest(string QID)
    {
        //Get the quest data based on the QID
        Quest q = QuestManager.Instance.FetchQuestInfo(QID);

        /* Get the position of the second to last child in the campaign screen, we will use it's position to position the new QuestTile
         * in the correct place
         */

        Vector2 NewPos;
        Transform child = homeScreen.transform.GetChild(homeScreen.transform.childCount - 1);
        Vector3 childPos = child.transform.position;


        if (homeScreen.transform.childCount == 1)
        {
            NewPos = new(childPos.x, Screen.currentResolution.height - 400);
        }

        else
        {

            NewPos = new(childPos.x, childPos.y - 650);
        }
        //Create a new Quest Tile
        GameObject questTileTemplate = Instantiate((GameObject)Resources.Load("QuestTile"), NewPos, new Quaternion(0, 0, 0, 0), homeScreen.transform);

        questTileTemplate.transform.GetChild(0).GetComponent<TMP_Text>().text = q.Title;
        questTileTemplate.transform.GetChild(1).GetComponent<TMP_Text>().text = q.ShortDescription;
        questTileTemplate.transform.GetChild(2).GetComponent<TMP_Text>().text = q.CoinsReward.ToString();
        questTileTemplate.transform.GetChild(3).GetComponent<TMP_Text>().text = q.LevelRequirement.ToString();
        questTileTemplate.transform.SetSiblingIndex(homeScreen.transform.childCount - 2);


        questTileTemplate.GetComponent<Button>().onClick.AddListener(() => { Debug.Log(q.Title); });

    }
    /*
     * Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full infomration
     * 
     */

    public void LinkToQuestOverviewScreen()
    {

    }


    public void RenderAllQuests(QuestManager manager)
    {
        foreach(var q in manager.quests)
        {
            RenderQuest(q.QuestID);
            Debug.Log(q.QuestID + " has been rendered");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
