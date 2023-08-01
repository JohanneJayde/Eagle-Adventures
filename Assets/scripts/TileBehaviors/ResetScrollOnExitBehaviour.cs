using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class AddResetScrollOnExitBehaviour : TileBehaviour
{


    public override void AddBehaviour(){

        Button.onClick.AddListener(

            () => {Screen.GetComponent<ScrollRect>().normalizedPosition = new Vector2(1,1);
            }
        );

    }


}
