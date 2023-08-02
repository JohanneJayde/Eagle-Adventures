using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class NewUserScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField NameField;
    public TMP_Dropdown SummerBridge;
    public Button CreateUserButton;
    public GameObject ProfileScreen;
    public GameObject Onboarding;

    public void createUser(){

        string group = SummerBridge.options[SummerBridge.value].text;
        string groupLetter = group[group.Length - 1].ToString().ToUpper();

        PlayerManager.Instance.CreateNewPlayer(NameField.text, groupLetter);

        TriggerOnboarding();
    }


    public void TriggerOnboarding(){
        gameObject.SetActive(false);
        ProfileScreen.SetActive(true);
        Onboarding.SetActive(true);
        Onboarding.GetComponent<TutorialFlow>().ActivateOnBoard();
    }

    void Start()
    {
        CreateUserButton.onClick.AddListener(
            () => {createUser();}
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
