using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResetScrollOnExitBehaviour : TileBehaviour
{
    


    public override void AddBehaviour(){

        Button.onClick.AddListener(

            () => 
            {
                Screen.name = "trest";
                Screen.GetComponent<ScrollRect>().normalizedPosition = new Vector2(1,1);
            }
        );

    }


}
