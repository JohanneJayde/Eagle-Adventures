using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsScreenConstructor : MonoBehaviour
{

    public static void ChestFoundChain(GameObject Screen){
        
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<ChestRewards>().ShowRewards(Screen.GetComponent<QuestDirectionsScreen>().Quest);
        ChestRewards.GetComponent<ChestRewards>().ReturnToProfilePage();
        GameObject ChestOpen = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestOpening"), Screen.transform.root, false) as GameObject;
        GameObject ChestFound = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestFound"), Screen.transform.root, false) as GameObject;
        ChestFound.GetComponent<ChestFound>().OpenChest(ChestOpen);

    }

    public void EnterCodeChain(Quest quest){

    }


}
