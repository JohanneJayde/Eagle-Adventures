using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExitOnClickBehaviour : ButtonBehaviour
{
    public void AddBehaviour(Button button, GameObject screen)
    {
        button.onClick.AddListener(
            ()=>
            {
                screen.SetActive(false);
            }
        );
    }
}
