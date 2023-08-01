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
        if(CheckCode()){

            Status.text = "Correct Answer!";
            RewardsScreenConstructor.ChestFoundSpecial(CodeField.text, gameObject);
            Destroy(gameObject);
        }
        else if(CodeField.text == "DELTEALLPLAYERDATA"){
            PlayerManager.Instance.DeleteSaveData();
        }
        else{
            Status.text = "Sorry! That answer was incorrect!";
        }
    }

    public bool CheckCode(){
        return CommerceManager.Instance.SpecialCodes.ContainsKey(CodeField.text);
    }
}
