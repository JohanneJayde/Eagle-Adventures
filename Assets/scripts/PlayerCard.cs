using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    public void RenderCard()
    {
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "Hello, " +  PlayerManager.Instance.Name;
        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + PlayerManager.Instance.Level.ToString();
        gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Coin Count: " + PlayerManager.Instance.CoinCount.ToString();

    }

    private void Start()
    {
        RenderCard();
    }

}
