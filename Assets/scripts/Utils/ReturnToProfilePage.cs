using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToProfilePage : MonoBehaviour
{


    public Button ReturnToProfileButton;

    public GameObject scrollview;

    void Start()
    {
        ReturnToProfileButton.onClick.AddListener(
            () =>
                {

                    if(scrollview != null){
                        scrollview.GetComponent<ScrollRect>().normalizedPosition = new Vector2(1,1);
                    }

                    gameObject.SetActive(false);
                }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
