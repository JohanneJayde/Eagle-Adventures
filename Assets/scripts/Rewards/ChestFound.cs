using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestFound : MonoBehaviour
{
    public Button OpenChestButton;


    public void OpenChest(GameObject Chest){
        OpenChestButton.onClick.AddListener(
            () => 
            {                
                Destroy(gameObject);
                Chest.GetComponent<ChestOpen>().GetChestRewards();
            }
        );
    }

}
