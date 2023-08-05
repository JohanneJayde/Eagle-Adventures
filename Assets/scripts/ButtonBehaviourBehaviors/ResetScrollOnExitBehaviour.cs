using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResetScrollOnExitBehaviour : ButtonBehaviour
{
    public void AddBehaviour(Button button, GameObject screen){

        button.onClick.AddListener(

            () => 
            {
                screen.name = "trest";
                screen.GetComponent<ScrollRect>().normalizedPosition = new Vector2(1,1);
            }
        );

    }


}
