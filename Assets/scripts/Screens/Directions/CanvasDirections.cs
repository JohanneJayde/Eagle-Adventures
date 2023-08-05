using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasDirections : QuestDirectionsScreen
{

    public override void HandlePress()
    {
        RewardsScreenConstructor.OpenCodeEntry(gameObject.transform.parent.gameObject);

    }


}
