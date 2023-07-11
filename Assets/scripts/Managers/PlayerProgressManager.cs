using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * TODO: This is going to be used to track player progress
 *
 * Due to how the program has been evolving, this script may be removed in favor of directly hooking it up
 * it will depend on how much the PlayerManager script changes when dynamic quests are added.
 */

public class PlayerProgressManager : MonoBehaviour
{

    public UnityEvent UpdateRenders;
/*
 * Singleton logic
 */
    private static PlayerProgressManager _instance;

    public static PlayerProgressManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }


    public void UpdateProgress(Quest quest)
    {

        PlayerManager.Instance.UpdateStats(quest);
        Debug.Log("Player Info Updated");
  
    }



    // Start is called before the first frame update
    void Start()
    {

    }


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }
}
