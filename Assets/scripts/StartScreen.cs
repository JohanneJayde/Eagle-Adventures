using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Button StartButton;
    public GameObject NewPlayerScreen;

    public GameObject ProfileScreen;

    void Start()
    {
        Debug.Log("This should happen after quests have finished");
        QuestManager.Instance.SetRewards();
        StartButton = gameObject.GetComponentInChildren<Button>();


        if(PlayerManager.Instance.CheckPlayerData()){
            StartButton.onClick.AddListener(() => {
                ProfileScreen.SetActive(true);
                PlayerManager.Instance.LoadExistingPlayer();
            });
        }
        else{
            StartButton.onClick.AddListener(() => {NewPlayerScreen.SetActive(true);});
        }

            StartButton.onClick.AddListener(() => {gameObject.SetActive(false);});




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
