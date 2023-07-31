using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class CampaignOverviewScreen : MonoBehaviour
{

    public GameObject TileParent;
    public List<GameObject> Tiles;
    public TMP_InputField SearchBar;
    public GameObject QuestScreen;

    void Start()
    {
        foreach (Transform child in TileParent.transform)
        {
            Tiles.Add(child.gameObject);
            child.gameObject.GetComponentInChildren<Button>().onClick.AddListener(
                () => 
                {
                    QuestScreen.GetComponent<QuestScreen>().SetQuests(child.gameObject.name);
                    QuestScreen.SetActive(true);
                    gameObject.SetActive(false);
                            ClearFilter();
                }
            );
        }

    SearchBar.onValueChanged.AddListener(delegate { SearchByTitle(); });

    }
    public void ClearFilter()
    {
        SearchBar.text = "";
        TileParent.transform.DetachChildren();
        List<GameObject> campaignTiles = Tiles.OrderBy(c => c.name).ToList();

        campaignTiles.ForEach((campaign)
         => {campaign.transform.SetParent(TileParent.transform);}
         );

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

        foreach (GameObject campaignTile in Tiles)
        {
            if (campaignTile.name.
                StartsWith(title, StringComparison.CurrentCultureIgnoreCase))
            {
                campaignTile.SetActive(true);
            }
            else
            {
                campaignTile.SetActive(false);
            }
        }
    }

    void onDisable(){
        Debug.Log("Diasabled");
        ClearFilter();
        SearchBar.text = "";
    }

}

