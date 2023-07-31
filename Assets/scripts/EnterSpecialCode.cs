using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterSpecialCode : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(
            () =>{
                OpenCodeScreen();
            }
        );
    }

    public void OpenCodeScreen(){
        Instantiate(Resources.Load("Prefabs/Rewards Collections/SpecialCodeEntry.prefab"), gameObject.transform.root, false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
