using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SpecialCodeEntry : MonoBehaviour
{

    public TMP_InputField CodeField;
    public Button EnterCode;
    public TMP_Text Status;
    public Button BackButton;

    public string code;

    void Start(){
        EnterCode.onClick.AddListener(
            () =>
            {
                HandlePress();
            }
        );
    }

    public void HandlePress(){
        string code = CodeField.text;
        if(CodeExists(code)){

            if(CheckUsedCode(code)){
                Status.text = "Sorry! That code has already been redeemed. Please ask for another one!";
            }
            else{
                Status.text = "Correct Code! Distributing Rewards!";
                RewardsScreenConstructor.ChestFoundSpecial(CodeField.text, gameObject);
                Destroy(gameObject);
            }


        }
        else if(CodeField.text == "DELETEPLAYERDATA"){
            Status.text = "DELETED ALL PLAYER DATA!";
            PlayerManager.Instance.DeleteSaveData();
        }
        else if(CodeField.text == "LEVELTONINE"){
            Status.text = "Level Bar should show 9 nine!";
            StatsManager.Instance.UpdateCoinsAndExp(2200, 5000);
        }
        else{
            Status.text = "ERROR! Invalid Code!";
        }
    }

    public bool CodeExists(string code){
        return CommerceManager.Instance.CodeExists(code);
    }
    public bool CheckUsedCode(string code){
        return CommerceManager.Instance.CheckUsedCode(code);

    }
}
