using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static QuestManager;

public class QuestRender : MonoBehaviour
{

    public GameObject homeScreen;
    GameObject questTileTemplate;

    // Start is called before the first frame update
    void Start()
    {
         questTileTemplate= (GameObject)Resources.Load("QuestTile");
    }

    public void AddQuest()
    {

        Quest q = QuestManager.Instance.FetchQuestInfo("A30");

        Debug.Log(q);

        questTileTemplate.transform.GetChild(0).GetComponent<TMP_Text>().text = q.Title;
        questTileTemplate.transform.GetChild(1).GetComponent<TMP_Text>().text = q.ShortDescription;
        questTileTemplate.transform.GetChild(2).GetComponent<TMP_Text>().text += q.CoinsReward.ToString();
        questTileTemplate.transform.GetChild(3).GetComponent<TMP_Text>().text += q.LevelRequirement.ToString();

        Instantiate(questTileTemplate, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), homeScreen.transform);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
