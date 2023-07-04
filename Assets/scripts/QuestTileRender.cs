using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTileRender : MonoBehaviour
{

    public Quest Quest { get; set; }


    public void Render(Quest q){
        Quest = q;
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = Quest.Title;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = Quest.ShortDescription;
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text += Quest.CoinsReward.ToString();
        gameObject.transform.GetChild(3).GetComponent<TMP_Text>().text += Quest.LevelRequirement.ToString();
        gameObject.name = Quest.Title;

        if(PlayerManager.Instance.Level < q.LevelRequirement)
        {
            gameObject.GetComponent<Button>().enabled = false;
        }

    }

    public void Unlock()
    {
        gameObject.GetComponent<Button>().enabled = true;

    }



    public void Attached()
    {
        Debug.Log("ATTACHED");
    }

    // Start is called before the first frame update
    void Start()
    {

        Quest = new Quest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
