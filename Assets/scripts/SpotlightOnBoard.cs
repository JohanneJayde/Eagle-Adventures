using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpotlightOnBoard : MonoBehaviour
{

    public GameObject ObjToSpotlight;
    public GameObject ClonedObject;

    public void Spotlight(){

        //nothing to spotlight;
        if(ObjToSpotlight == null){
            return;
        }

        ClonedObject = Instantiate(ObjToSpotlight, gameObject.transform.root, false) as GameObject;

        ObjToSpotlight.SetActive(false);
        Vector3 pos = ObjToSpotlight.transform.position;
        ClonedObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        ClonedObject.transform.SetSiblingIndex(0);

    }

    public void OffSpotlight(){

        if(ObjToSpotlight == null){
            return;
        }


        Destroy(ClonedObject);
        ObjToSpotlight.SetActive(true);
    }

    public void Start(){
        Spotlight();
    }

    //If there is no continute button, then we we have to assign our spotlight's button
    //so it can move the onboarding foward
    public void AddActiveOnBoard(){

    }

}
