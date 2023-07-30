using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveScreen : MonoBehaviour
{

    public Button ReturnToProfileButton;


    void Start()
    {
                ReturnToProfileButton.onClick.AddListener(
            () =>
                {
                    Destroy(gameObject);
                }
        );
    }

}
