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
    public QuestTileSupllier Supplier {get; set;}

    void Start()
    {
        Supplier = new QuestTileSupllier(content);
        ClearFilter();
        Supplier.CreateAllTiles();
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