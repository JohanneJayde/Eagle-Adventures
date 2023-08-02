using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CopyElement : MonoBehaviour
{
    public GameObject CloneObject;

    public GameObject canvas;

    public Button SendBack;

    public void ClickClone(){
       // GameObject ClonedObject = Instantiate(CloneObject, CloneObject.transform.position, CloneObject.transform.rotation);

        Debug.Log(CloneObject.transform.position);

        //211.21


        GameObject ClonedObject = Instantiate(CloneObject, canvas.transform, false);
        CloneObject.SetActive(false);
        Vector3 pos = CloneObject.transform.position;

        ClonedObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        //ClonedObject.transform.SetParent(canvas.transform, false);
        Debug.Log(ClonedObject.transform.position);

        SendBack.onClick.AddListener(
            () =>
            {
                CloneObject.SetActive(true);
                Destroy(ClonedObject);
            }
        );

    }
}
