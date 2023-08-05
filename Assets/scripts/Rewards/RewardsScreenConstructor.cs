using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsScreenConstructor : MonoBehaviour
{
    public static void ChestFoundChain(Quest quest, GameObject Screen){
        GameObject ChestRewards = GetRewardsScreen(quest, Screen);
        SetOpenAndFoundScreens(Screen);

    }

    public static void SetOpenAndFoundScreens(GameObject Screen){
        GameObject ChestOpen = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestOpening"), Screen.transform.root, false) as GameObject;
        GameObject ChestFound = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestFound"), Screen.transform.root, false) as GameObject;
        ChestFound.GetComponent<ChestFound>().OpenChest(ChestOpen);
    }

    public static GameObject GetRewardsScreen(Quest Quest, GameObject Screen){
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/ChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<ChestRewards>().ShowRewards(Quest);
        ChestRewards.GetComponent<ChestRewards>().ReturnToProfilePage();
        return ChestRewards;
    }

    public static void OpenCodeEntry(GameObject Screen){
        GameObject CodeEntry = Instantiate(Resources.Load("Prefabs/Rewards Collections/CodeEntry"), Screen.transform.root, false) as GameObject;
        CodeEntry.GetComponent<CodeEntry>().SetCode(Screen.GetComponent<QuestDetailScreen>().Quest);
        CodeEntry.GetComponent<CodeEntry>().DirectionScreen = Screen;
        CodeEntry.GetComponent<CodeEntry>().EnterCode.onClick.AddListener(
            () =>
            {
                 CodeEntry.GetComponent<CodeEntry>().HandlePress();
            }
        );
    }

    public static void ChestFoundSpecial(string code, GameObject Screen){
        GameObject ChestRewards = Instantiate(Resources.Load("Prefabs/Rewards Collections/SpecialChestRewards"), Screen.transform.root, false) as GameObject;
        ChestRewards.GetComponent<SpecialCodeRewards>().ShowRewards(code);
        ChestRewards.GetComponent<SpecialCodeRewards>().ReturnToProfilePage();
        GameObject ChestOpen = Instantiate(Resources.Load("Prefabs/Rewards Collections/SpecialChestOpening"), Screen.transform.root, false) as GameObject;
        GameObject ChestFound = Instantiate(Resources.Load("Prefabs/Rewards Collections/SpecialChestFound"), Screen.transform.root, false) as GameObject;
        ChestFound.GetComponent<ChestFound>().OpenChest(ChestOpen);
    }


}
