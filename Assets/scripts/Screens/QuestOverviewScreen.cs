using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/*
 * OverviewScreen is the logic for the overview screen that allows users to search and filter quests based on conditions
 * A user will also be able to launch a quest from this screen.
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
    public QuestTileSupplier Supplier {get; set;}

    public void ClearFilter()
    {

        content.transform.DetachChildren();

        List<GameObject> Quests = QuestTiles.OrderBy(q => q.GetComponent<QuestTile>().Quest.Title).ToList();

        Quests.ForEach((quest)
         => {quest.transform.SetParent(content.transform);}
         );

        //Implement own quicksort, to fix issue with not sorting in place

        //Seperate Tile Sorter and Tile Filter to avoid issues with filter and sorter conflicting

    }

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
    void Start()
    {
        Supplier = new QuestTileSupplier(content);
        QuestTiles = Supplier.CreateAllTiles();
        SearchBar.onValueChanged.AddListener(delegate { SearchByTitle(); });
    }
}