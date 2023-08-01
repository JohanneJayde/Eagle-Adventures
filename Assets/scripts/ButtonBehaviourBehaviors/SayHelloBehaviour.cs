using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SayHelloBehaviour : ButtonBehaviour
{
    public void AddBehaviour(Button button, GameObject screen){

        button.onClick.AddListener(

            () => 
            {
                Debug.Log("Hello World!");

            }
        );

    }
}
