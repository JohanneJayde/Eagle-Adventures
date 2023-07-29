using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Button StartButton;

    void Start()
    {
        Debug.Log("This should happen after quests have finished");
        QuestManager.Instance.SetRewards();
        StartButton = gameObject.GetComponentInChildren<Button>();

        StartButton.onClick.AddListener(() => {Debug.Log("Working");});

        // QuestManager.Instance.Quests.ForEach( quest =>
        //     Debug.Log(quest.CoinRewards + " " + quest.ExpRewards)
        // );
    }

    public void check(){
        Debug.Log("HI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
