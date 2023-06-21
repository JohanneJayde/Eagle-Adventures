using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProfilePage : MonoBehaviour
{
    
    public GameObject questPage;
    public GameObject profilePage;
    
    public Image personalityTile;
    public Image campaignTile1;
    public Image campaignTile2;
    public Image campaignTile3;
    public Image campaignTile4;

    public TMP_Text personalityType;
    public TMP_Text personalityDescription;

    /*
    On Start, it fetches the user's type and it's description from PlayerPrefs
    */
    void Start()
    {
        personalityType.text += PlayerPrefs.GetString("type", "none");
        personalityDescription.text += PlayerPrefs.GetString("typeDesc", "nanna");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
