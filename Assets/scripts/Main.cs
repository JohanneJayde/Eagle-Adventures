using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Main : MonoBehaviour
{

    /*
     * GameObjects that are serving as containers for each screen a user will visit before reaching main app flow;
     */
    public GameObject TitlePage;
    public GameObject NewEagleScreen;
    public GameObject SortingQuizIntroScren;
    public GameObject ProfileScreen;

    public Button EnterButton;

    /*
     * Variable that are used when creating a new user's basic profile info
     */

    public TMP_InputField nameField;
    public Button createUserButton;

    /*
     * LoadNewEagleScreen loads in the screen for creating a new Eagle avatar. This only happens if checkPlayerData() evalulates to false
     */

    public void LoadNewEagleScreen()
    {
        Debug.Log("Load Onboarding Screen");
        NewEagleScreen.SetActive(true);

        createUserButton.onClick.AddListener(() => RegisterNewPlayer());

        TitlePage.SetActive(false);
    }

    /*
     * LoadProfileScreen will load in the profile page for a user when they have been found to have existing account info
     */

    public void LoadProfileScreen()
    {
        ProfileScreen.SetActive(true);
        TitlePage.SetActive(false);
    }

    /*
     * RegisterNewUser will take the infomation that the user inputs and create a player around them. 
     */
    public void RegisterNewPlayer()
    {
        PlayerManager.Instance.CreateNewPlayer(nameField.text);

    }

    public void LoadNextScreen()
    {
        bool playerData = PlayerManager.Instance.CheckPlayerData();

        if (playerData)
        {
            Debug.Log("Player Found");
            Debug.Log(PlayerManager.Instance);
            LoadProfileScreen();
        }
        else
        {
            Debug.Log("No Player Found");
            LoadNewEagleScreen();
        }
    }

    /*
     * On Start(), the program uses PlayerManager to check if existing player has been stored.
     * If it has, then EnterButton onclick event will redirect to the profile page
     * If there is none, then the EnterButton should direct them to the user creation screen
     * It should also set up the confirm button for the createUserButton.
     */
    void Start(){

        EnterButton.onClick.AddListener(() => LoadNextScreen());

    }
}
