using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnClickBehaviour : TileBehaviour
{


    public override void AddBehaviour()
    {
        Button.onClick.AddListener(
            ()=>
            {
                Screen.SetActive(false);
            }
        );
    }
}
