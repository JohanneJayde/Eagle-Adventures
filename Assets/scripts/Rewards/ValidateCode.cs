using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValidateCode : MonoBehaviour
{

    public TMP_InputField CodeField;
    public TMP_Text Status;
    public GameObject nextScreen;
    public Button button;
    public TMP_Text CoinsEarned;

    public void HandlePress(){
        string code = CodeField.text;
        if(CodeExists(code, "603465")){
            DoAction();
        }
        else{
            Status.text = "ERROR! Invalid Code!";
        }
    }

    public bool CodeExists(string code, string codeToCheck){
        return code == codeToCheck;
    }

    public void DoAction(){
        PlayerManager.Instance.EmptyCoins();
        gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }

    public void Start(){
        button.onClick.AddListener(
            () => {
                HandlePress();
            }
        );
        CoinsEarned.text = PlayerManager.Instance.CoinCount.ToString() + "G";
    }
}
