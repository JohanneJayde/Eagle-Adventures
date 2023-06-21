using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject SortingQuiz;
    public GameObject LoginScreen;
    public GameObject DebugScreen;

    public Image group1;
    public Image group2;

    /*
    Loads the Sorting Quiz page once the user states they are a new Eagle
    */
    public void startSortingQuiz()
    {
        SortingQuiz.SetActive(true);
        DebugScreen.SetActive(false);
    }

    public void setGroup(){

    }

    void Start(){
    }
}
