using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public abstract class TileBehaviour : MonoBehaviour
{

    public Button Button;
    public GameObject Screen;

    public void SetComponents(Button button, GameObject screen){
        Button = button;
        Screen = screen;
    }

    public abstract void AddBehaviour();
}
