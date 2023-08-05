using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScroll : MonoBehaviour
{
    void OnDisable(){
        gameObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(1,1);
    }
}
