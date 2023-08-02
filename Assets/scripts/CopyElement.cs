using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class OnboardingProcess : MonoBehaviour
{
    public GameObject CloneObject;

    public List<GameObject> OnBoardBlurbs;

    public GameObject finalscreen;

    public GameObject profileScreen;

    public GameObject TutorialScreens;

    public Volume BlurEffect;

    public GameObject canvas;

    public Button SendBack;

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

    public void ClickClone(){
       // GameObject ClonedObject = Instantiate(CloneObject, CloneObject.transform.position, CloneObject.transform.rotation);

        foreach(var bord in OnBoardBlurbs){
            Debug.Log("Hi");
        }

        Debug.Log(CloneObject.transform.position);

        GameObject ClonedObject = Instantiate(CloneObject, canvas.transform, false);
        CloneObject.SetActive(false);
        Vector3 pos = CloneObject.transform.position;

        ClonedObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        //ClonedObject.transform.SetParent(canvas.transform, false);
        Debug.Log(ClonedObject.transform.position);

        SendBack.onClick.AddListener(
            () =>
            {
                CloneObject.SetActive(true);
                Destroy(ClonedObject);
            }
        );

    }
}
