using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTile : MonoBehaviour
{


    public Quest Quest { get; set; }

    public void Render() {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.ShortDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coins: " + Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "Level Requirement: " + Quest.LevelRequirement.ToString();
        gameObject.name = Quest.Title;

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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
