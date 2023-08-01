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
                CheckCode();
            }
        );
    }

    public void CheckCode(){
        if(CommerceManager.Instance.SpecialCodes.Any((code) => { return CodeField.text == code.code;})){

            Status.text = "Correct Answer!";
            //RewardsScreenConstructor.ChestFoundSpecial();
            Destroy(gameObject);
        }
        else if(CodeField.text == "DELTEALLPLAYERDATA"){
            PlayerManager.Instance.DeleteSaveData();
        }
        else{
            Status.text = "Sorry! That answer was incorrect!";
        }

    }
}
