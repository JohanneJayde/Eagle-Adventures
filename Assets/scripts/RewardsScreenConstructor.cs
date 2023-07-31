using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsScreenConstructor : MonoBehaviour
{
    public static void ChestFoundChain(GameObject Screen){
        
        GameObject ChestRewards = GetRewardsScreen(Screen);
        SetOpenAndFoundScreens(Screen);

    }

    public static void SetOpenAndFoundScreens(GameObject Screen){
        GameObject ChestOpen = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestOpening"), Screen.transform.root, false) as GameObject;
        GameObject ChestFound = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestFound"), Screen.transform.root, false) as GameObject;
        ChestFound.GetComponent<ChestFound>().OpenChest(ChestOpen);
    }

    public static GameObject GetRewardsScreen(GameObject Screen){
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<ChestRewards>().ShowRewards(Screen.GetComponent<QuestDirectionsScreen>().Quest);
        ChestRewards.GetComponent<ChestRewards>().ReturnToProfilePage();
        return ChestRewards;
    }

    public static void ChestFoundChainCodeEntry(GameObject Screen){
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<ChestRewards>().ShowRewards(Screen.GetComponent<CodeEntry>().Quest);
        ChestRewards.GetComponent<ChestRewards>().ReturnToProfilePage();
        SetOpenAndFoundScreens(Screen);
    }

    public static void OpenCodeEntry(GameObject Screen){
        GameObject CodeEntry = Instantiate(Resources.Load("Prefabs/Rewards Collections/CodeEntry"), Screen.transform.root, false) as GameObject;
        CodeEntry.GetComponent<CodeEntry>().SetCode(Screen.GetComponent<QuestDirectionsScreen>().Quest);
        CodeEntry.GetComponent<CodeEntry>().DirectionScreen = Screen;
        CodeEntry.GetComponent<CodeEntry>().EnterCode.onClick.AddListener(
            () =>
            {
                 CodeEntry.GetComponent<CodeEntry>().HandlePress();
            }
        );
    }

    public static void ChestFoundSpecial(GameObject Screen){
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<ChestRewards>().ShowRewards(Screen.GetComponent<CodeEntry>().Quest);
        ChestRewards.GetComponent<ChestRewards>().ReturnToProfilePage();
        GameObject ChestOpen = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestOpening"), Screen.transform.root, false) as GameObject;
        GameObject ChestFound = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestFound"), Screen.transform.root, false) as GameObject;
        ChestFound.GetComponent<ChestFound>().OpenChest(ChestOpen);
    }


}
