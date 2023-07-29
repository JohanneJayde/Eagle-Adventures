using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject ProfileScreen;

    public GameObject CampaignQuestScreen;
    public GameObject LastQuestScreen;
    public GameObject CodeScreen;

    public Button SendToOverview;
    public Button SendToLastQuest;
    public Button SendToCodeScreen;

    public void SwapScreen (GameObject screen){
        screen.SetActive(true);
        ProfileScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SendToOverview.onClick.AddListener( () => {SwapScreen(CampaignQuestScreen);});
        SendToLastQuest.onClick.AddListener( () => {SwapScreen(LastQuestScreen);});
        SendToCodeScreen.onClick.AddListener( () => {SwapScreen(CodeScreen);});
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
