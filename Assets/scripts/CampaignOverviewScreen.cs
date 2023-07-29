using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CampaignOverviewScreen : MonoBehaviour
{

    public GameObject Tiles;

    public TMP_InputField SearchBar;

    void Start()
    {
        foreach (Transform child in Tiles.transform)
        {
            child.gameObject.GetComponentInChildren<Button>().onClick.AddListener(
                () => 
                {
                    Debug.Log("HI");
                }
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
