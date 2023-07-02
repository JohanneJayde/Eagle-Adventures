using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestManager;
using TMPro;
using UnityEngine.UI;

public class QuestDetailsRenderer : MonoBehaviour
{

    //the current quest the page is rendering
    public Quest Quest { set; get; }

    public void RenderDetails() {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.LongDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text = Quest.ExpEarned.ToString();
        gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { Application.OpenURL(Quest.CanvasURL.ToString()); });

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
