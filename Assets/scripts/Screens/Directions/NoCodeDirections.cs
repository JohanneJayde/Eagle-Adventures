using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoCodeDirections : QuestDirectionsScreen
{


    public override void RenderQuest(Quest quest){

        base.RenderQuest(quest);

        if(PlayerManager.Instance.PlayerProgress[quest.QuestID]){
            SendScreen.enabled = false;
        }

    }


    public override void HandlePress()
    {
            RewardsScreenConstructor.ChestFoundChain(Quest, gameObject);
            gameObject.transform.parent.gameObject.SetActive(false);
    }


}
