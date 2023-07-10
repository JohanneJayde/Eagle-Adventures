using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTile : MonoBehaviour
{


    public Quest Quest { get; set; }
    public GameObject QuestScreen;
    public void Render() {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.ShortDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coins: " + Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "Level Requirement: " + Quest.LevelRequirement.ToString();
        gameObject.name = Quest.Title;

        PlayerManager.Instance.onLevelUp.AddListener(gameObject.GetComponent<QuestTile>().SetLockStatus);
        gameObject.GetComponent<Button>().onClick.AddListener(() => RenderDetails(Quest));


        SetLockStatus();

    }

    public void Unlock()
    {
        gameObject.GetComponent<Button>().enabled = true;
        gameObject.GetComponent<Image>().color = new Color32(255,189,189,255);

        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().color = Color.black;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().color = Color.black;
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().color = Color.black;

    }

    public void Lock()
    {
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<Image>().color = new Color32(255,97,97,255);

        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().color = Color.white;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().color = Color.white;
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().color = Color.white;
    }

    public void SetLockStatus(){
        if(PlayerManager.Instance.Level >= Quest.LevelRequirement)
        {
            Unlock();
        }
        else
        {
            Lock();
        }

    }


    /*
    * Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full information
    * This is done by first setting the details script's Quest Property to the Quest that we want to render info for.
    * It calls SetScreenDetails on the QuestScren to display it's info and activates the screen to show off the info.
    */
    public void RenderDetails(Quest quest)
    {

        QuestScreen.GetComponent<QuestScreen>().SetScreenDetails(quest);
        QuestScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        QuestScreen = QuestManager.Instance.QuestScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
