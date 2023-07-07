using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTile : MonoBehaviour
{


    public Quest Quest { get; set; }

    public bool IsLocked { get; set;}

    public GameObject QuestScreen;

    public void Render() {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.ShortDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coins: " + Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "Level Requirement: " + Quest.LevelRequirement.ToString();
        gameObject.name = Quest.Title;
        gameObject.GetComponent<Button>().onClick.AddListener(() => RenderDetails());

        if(PlayerManager.Instance.Level >= Quest.LevelRequirement)
        {
            IsLocked = false;
            Unlock();
        }
        else
        {
            IsLocked = true;

            Lock();
        }


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

    /*
* Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full information
* This is done by first setting the details script's Quest Property to the Quest that we want to render info for.
* Then call RenderDetails to render the quest info on the screen and swap to the screen to show the details.
*/

    public void RenderDetails()
    {

        QuestScreen.GetComponent<QuestScreen>().SetScreenDetails(Quest);
        QuestScreen.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => { Unlock(); });
        QuestScreen.SetActive(true);
    }


    public void Attached()
    {
        Debug.Log("ATTACHED");
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
