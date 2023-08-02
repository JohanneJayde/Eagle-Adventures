using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFinish : MonoBehaviour
{

    public GameObject ProfileScreen;


    public void ReturnToNormalPlay(){
        Destroy(gameObject.transform.parent.gameObject);
        PlayerManager.Instance.UpdateCoinXP(50,50);
        ProfileScreen.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
