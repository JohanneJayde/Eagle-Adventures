using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialCodeRewards : MonoBehaviour
{
    public Button ReturnToProfileButton;
    public TMP_Text Coins;
    public void ShowRewards(string code){
        int coins = CommerceManager.Instance.SpecialCodes[code];
        Coins.text = coins.ToString() + "G";
        PlayerManager.Instance.UpdateCoins(coins);
    }

    public void ReturnToProfilePage(){
        ReturnToProfileButton.onClick.AddListener(
            () =>
            {
                Destroy(gameObject);
            }
        );
    }
}
