using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSelectMenu : MonoBehaviour
{

    public GameObject ProfileScreen;

    public GameObject CampaignQuestScreen;
    public GameObject RedeemCoin;
    public GameObject CodeScreen;

    public Button SendToOverview;
    public Button SendToCoinRedeem;
    public Button SendToCodeScreen;

    public void SwapScreen (GameObject screen){
        screen.SetActive(true);
        //ProfileScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SendToOverview.onClick.AddListener( () => {

            SwapScreen(CampaignQuestScreen);
            });
        SendToCoinRedeem.onClick.AddListener( () => {SwapScreen(RedeemCoin);});
        SendToCodeScreen.onClick.AddListener( () => {
        Instantiate(CodeScreen, gameObject.transform.root, false);
        SwapScreen(CodeScreen);});
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
