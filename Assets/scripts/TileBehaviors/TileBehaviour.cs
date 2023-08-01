using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public abstract class TileBehaviour : Component
{

    public Button Button {get; set;}
    public GameObject Screen {get; set;}

    // public TileBehaviour(Button button, GameObject screen){
    //     Button = button;
    //     Screen = screen;
    // }
    public abstract void AddBehaviour();
}
