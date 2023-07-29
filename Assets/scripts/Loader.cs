using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This should happen after quests have finished");
        QuestManager.Instance.Quests.ForEach(quest => {Debug.Log(quest.Title);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
