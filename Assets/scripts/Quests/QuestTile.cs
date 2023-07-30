using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTile : MonoBehaviour
{

    public Quest Quest {get; set;}
    public TMP_Text title;
    public TMP_Text tagline;
    public TMP_Text description;

    public Button StartButton;


    public void RenderTile(Quest quest){
        Quest = quest;
        title.text = Quest.Title;
        tagline.text =  "Level: " + Quest.Level.ToString() + " | " + Quest.Theme;

        if( Quest.Description.Length > 256){
            description.text = Quest.Description.Substring(0,250) + "...";
        }
        else{
            description.text = Quest.Description;

        }


    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
