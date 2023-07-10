using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/*
 * QuestRender handles rendering a set or individual Quests on the app.
 */

public class OverviewScreen : MonoBehaviour
{
    /*
     * QuestDetailsScreen references the screen where individual Quest info will
     * be displayed
     */

    public GameObject content;
    public TMP_InputField SearchBar;

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

        QuestTiles = QuestManager.Instance.Supplier.CreateAllTiles();

        foreach(GameObject q in QuestTiles){
            q.transform.SetParent(content.transform, false);
        }

    }


    // On start, RenderAllQuests will render the quests in the Quest Overview screen
    void Start()
    {
       ClearFilter();
       RenderAllQuests();
       SearchBar.onValueChanged.AddListener(delegate { SearchByTitle(); });

    }


    public void ClearFilter()
    {

        
        foreach (GameObject questTile in QuestTiles.Where((qt) => qt.activeSelf == false))
        {
            questTile.SetActive(true);
        }


    }


    /*
     * Make it so that QuestTile Render method invokes an update statement which changes what the screen displays
     */

    public void SearchByTitle()
    {
        FilterByTitle(SearchBar.text);
    }

    public void FilterByTitle(string title)
    {
        if(title == "")
        {
            ClearFilter();
        }

        foreach (GameObject Quest in QuestTiles)
        {
            if (Quest.GetComponent<QuestTile>().Quest.Title.
                StartsWith(title, StringComparison.CurrentCultureIgnoreCase))
            {
                Quest.SetActive(true);
            }
            else
            {
                Quest.SetActive(false);
            }
        }
    }

}