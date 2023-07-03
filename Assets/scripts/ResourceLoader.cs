using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * TODO: We should shift all the copying of data and loading of data into this folder and then having app call these function
 * Consolodate loading function into this one script
 */

public class ResourceLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        QuestManager.Instance.LoadQuests();
        File.WriteAllText(Application.persistentDataPath + "/playerProgress.json", "hi");
        if (PlayerManager.Instance.CheckPlayerData())
        {
            PlayerManager.Instance.CreateNewPlayer();
        }
        else
        {
            PlayerManager.Instance.LoadExistingPlayer();
        }
    }
}
