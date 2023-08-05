using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
 
    public void CheckChest(){
    }

    public void GetChestRewards(){
        Destroy(gameObject, 2);
    }

    public void OnEnable(){
        Destroy(gameObject, 2);

    }

}
