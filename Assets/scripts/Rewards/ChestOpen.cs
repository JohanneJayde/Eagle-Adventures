using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
 

    public void Start(){
    }

    IEnumerator DeactivateScreen(){

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }

    public void CheckChest(){
    }

    public void GetChestRewards(){

        StartCoroutine(DeactivateScreen());   
     }


}
