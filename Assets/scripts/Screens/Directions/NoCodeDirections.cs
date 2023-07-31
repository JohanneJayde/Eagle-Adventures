using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoCodeDirections : QuestDirectionsScreen
{


    public override void RenderDirections(Quest quest){

        base.RenderDirections(quest);

        if(PlayerManager.Instance.PlayerProgress[quest.QuestID]){
            SendScreen.enabled = false;
        }

    }


    public override void HandlePress()
    {
            RewardsScreenConstructor.ChestFoundChain(gameObject);
            Destroy(gameObject);
    }


}
