using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{

    public GameObject PrevScreen;
    public GameObject NextScreen;

    public void SwapScreen(){
        PrevScreen.SetActive(false);
        NextScreen.SetActive(true);
    }

}
