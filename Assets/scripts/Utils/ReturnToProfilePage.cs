using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToProfilePage : MonoBehaviour
{


    public Button ReturnToProfileButton;

    void Start()
    {
        ReturnToProfileButton.onClick.AddListener(
            () =>
                {

                    gameObject.SetActive(false);
                }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
