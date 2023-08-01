using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayHelloBehaviour : TileBehaviour
{
    public override void AddBehaviour(){

        Button.onClick.AddListener(

            () => 
            {
                Debug.Log("Hello World!");
            }
        );

    }
}
