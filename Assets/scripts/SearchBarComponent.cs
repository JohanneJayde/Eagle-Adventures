using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class SearchBarComponent : MonoBehaviour
{

    public GameObject ItemsContainer;
    public TMP_InputField SearchBar;
    public List<GameObject> SearchableItems;

    public void init(){
        SearchBar.onValueChanged.AddListener(delegate { SearchByTitle(); });
        BuildSearchList();
        ClearFilter();

    }

    public void BuildSearchList(){

        foreach (Transform child in ItemsContainer.transform)
        {
            SearchableItems.Add(child.gameObject);
        }

    }

    public void ClearFilter(){
        SearchBar.text = "";
        ItemsContainer.transform.DetachChildren();
        List<GameObject> campaignTiles = SearchableItems.OrderBy(c => c.name).ToList();

        campaignTiles.ForEach((campaign)
         => {campaign.transform.SetParent(ItemsContainer.transform);}
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

        foreach (GameObject campaignTile in SearchableItems)
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

    void OnDisable(){
        Debug.Log("Diasabled");
        ClearFilter();
        SearchBar.text = "";
    }
    void OnEnable(){
        init();
    }

}
