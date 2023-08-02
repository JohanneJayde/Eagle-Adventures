using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class TutorialFlow : MonoBehaviour
{
    public List<GameObject> OnBoardBlurbs;
    public GameObject profileScreen;
    public GameObject TutorialScreens;
    public GameObject QuestScreen;
    public GameObject CampaignSceen;

    public Volume BlurEffect;
    public GameObject canvas;
    public int currentOnBoardBlur = 0;

    public void ActivateOnBoard(){

        if(currentOnBoardBlur == OnBoardBlurbs.Count){
            OnBoardBlurbs.ElementAt(currentOnBoardBlur - 1).SetActive(false);
            OnBoardBlurbs.ElementAt(currentOnBoardBlur - 1).GetComponent<SpotlightOnBoard>().OffSpotlight();
            Debug.Log("end of tutorial");
            Destroy(gameObject);
            return; 
        }

        OnBoardBlurbs.ElementAt(currentOnBoardBlur).SetActive(true);

        if(currentOnBoardBlur != 0){

            OnBoardBlurbs.ElementAt(currentOnBoardBlur - 1).SetActive(false);
            OnBoardBlurbs.ElementAt(currentOnBoardBlur - 1).GetComponent<SpotlightOnBoard>().OffSpotlight(); 

        }

        currentOnBoardBlur++;
    }

    public void QuitTutorial(){
        OnBoardBlurbs.ElementAt(currentOnBoardBlur - 1).GetComponent<SpotlightOnBoard>().OffSpotlight(); 
        Destroy(canvas);
        Destroy(TutorialScreens);
        CampaignSceen.SetActive(false);
       // QuestScreen.SetActive(false);
        profileScreen.SetActive(true);
    }
 
}
