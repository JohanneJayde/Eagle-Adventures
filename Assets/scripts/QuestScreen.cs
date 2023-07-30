using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestScreen : MonoBehaviour
{

    public List<Quest> Quests;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var quest in Quests){
            Debug.Log(quest.Title);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuests(string campaign){
        Quests = QuestManager.Instance.Quests.Where((quest) => {return quest.Session == campaign;}).ToList();
    }

}
