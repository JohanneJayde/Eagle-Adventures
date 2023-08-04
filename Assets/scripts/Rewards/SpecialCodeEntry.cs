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
            PlayerManager.Instance.DeleteSaveData();
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
