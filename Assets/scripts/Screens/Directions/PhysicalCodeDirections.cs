using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class PhysicalCodeDirections : QuestDirectionsScreen
{

    public override void HandlePress()
    {
        RewardsScreenConstructor.OpenCodeEntry(gameObject);
    }


}
