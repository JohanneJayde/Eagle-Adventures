using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

/*
 * This script renders the details of a quest onto the Quest Details screen
 */
public class QuestScreen : MonoBehaviour
{

    public GameObject OverviewScreen;

    //the current quest the page is rendering. This has been preset from OpenQuestDetailsScreen although it may switch
    public Quest Quest { set; get; }


    /*
     * Render the info to the user. An onClick listener is added so that the user may open the canvas assignment
     * that is needed to be completed to get code
     * 
     * TODO: Currently it only suppots IOS deeplinking when we need to support android DL as well.
     */
    public void SetScreenDetails(Quest quest) {
        Quest = quest;
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.LongDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coin Reward: " + Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "XP Reward: " + Quest.ExpEarned.ToString();
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { Application.OpenURL(Quest.CanvasURL.ToString()); });

        if (IsCompleted(Quest))
            Complete();
        else
        {
            Incomplete();
        }

        gameObject.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => SubmitCode());
    }

    public void Complete()
    {
        gameObject.transform.GetChild(6).GetComponent<Button>().enabled = false;
        gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().enabled = false;
        gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().text = Quest.Code;
        gameObject.GetComponent<Image>().color = new Color32(255,97,97,255);

    }

    public void Incomplete()
    {
        gameObject.transform.GetChild(6).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().enabled = true;
        gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().text = "";
        gameObject.GetComponent<Image>().color = new Color32(255,189,189,255);

    }

    private void SubmitCode()
    {

        string userInput = gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().text;

        if (Quest.Code.Equals(userInput))
        {
            Debug.Log("Correct Code");
            gameObject.transform.GetChild(6).GetComponent<Button>().enabled = false;
            gameObject.transform.GetChild(5).GetComponent<TMP_InputField>().enabled = false;

            PlayerProgressManager.Instance.UpdateProgress(Quest);
        }
        else
        {

            Debug.Log("Incorrect Code");
        }

    }

    public bool IsCompleted(Quest quest)
    {
        return PlayerManager.Instance.PlayerProgress[quest.QuestID];
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
