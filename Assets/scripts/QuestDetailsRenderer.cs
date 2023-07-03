using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestManager;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

/*
 * This script renders the details of a quest onto the Quest Details screen
 */
public class QuestDetailsRenderer : MonoBehaviour
{

    //the current quest the page is rendering. This has been preset from OpenQuestDetailsScreen although it may switch
    public Quest Quest { set; get; }

    /*
     * Render the info to the user. An onClick listener is added so that the user may open the canvas assignment
     * that is needed to be completed to get code
     * 
     * TODO: Currently it only suppots IOS deeplinking when we need to support android DL as well.
     */
    public void RenderDetails() {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.LongDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = Quest.ExpEarned.ToString();
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { Application.OpenURL(Quest.CanvasURL.ToString()); });
        gameObject.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => SubmitCode());
    }

    private void SubmitCode()
    {

        string userInput = gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().text;

        if (Quest.Code.Equals(userInput))
        {
            Debug.Log("Correct Code");
            PlayerProgressManager.Instance.UpdateProgress(Quest);
        }
        else
        {

            Debug.Log("Incorrect Code");
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
