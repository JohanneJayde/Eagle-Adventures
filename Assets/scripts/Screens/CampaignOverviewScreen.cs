using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class CampaignOverviewScreen : MonoBehaviour
{

    public GameObject Tiles;
    public TMP_InputField SearchBar;
    public GameObject QuestScreen;

    void Start()
    {
        foreach (Transform child in Tiles.transform)
        {
            child.gameObject.GetComponentInChildren<Button>().onClick.AddListener(
                () => 
                {
                    QuestScreen.GetComponent<QuestScreen>().SetQuests(child.gameObject.name);
                    QuestScreen.SetActive(true);
                    gameObject.SetActive(false);
                }
            );
            
        }

    }

}

