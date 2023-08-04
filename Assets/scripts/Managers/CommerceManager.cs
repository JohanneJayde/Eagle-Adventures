using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Events;

public class CommerceManager : MonoBehaviour
{
    /*
    * Singleton logic
    */
    private static CommerceManager _instance;
    public Dictionary<string, int> SpecialCodes {get; set;}
    public Dictionary<string, bool> UsedCodes {get; set;}
    public struct SpecCode{
        public string code;
        public int amount;
        public bool used;

    }

    [SerializeField]
    public TextAsset SpecialCodesJSON {get; set;}


    public static CommerceManager Instance
    { get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        SpecialCodes = new Dictionary<string, int>();
        UsedCodes = new Dictionary<string, bool>();

        if(CheckCodesJsonExists()){
            LoadSpecialCodesLookUp();
        }
        else{
            CreateSpecialCodesLookUp();
        }
        
    }

    public void LoadSpecialCodesLookUp(){

        SpecialCodes = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(Application.persistentDataPath + "/specialCodes.json"));
        UsedCodes = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(Application.persistentDataPath + "/playerUsedSpecialCodes.json"));
    }


    public void CreateSpecialCodesLookUp(){
        Debug.Log("Loading Json");
        TextAsset json = Resources.Load("Data/SpecialCodes") as TextAsset;
        Debug.Log(json.text);
        List<SpecCode> specCodes = new List<SpecCode>();
        specCodes = JsonConvert.DeserializeObject<List<SpecCode>>(json.text);
        foreach(var code in specCodes){
            SpecialCodes.Add(code.code, code.amount);
            UsedCodes.Add(code.code, false);
        }
        File.WriteAllText(Application.persistentDataPath + "/specialCodes.json", JsonConvert.SerializeObject(SpecialCodes));
   
    }

    public void UpdateUsedCodes(string code){
        UsedCodes[code] = true;
        SaveUsedCodes();

    }

    public bool CheckCodesJsonExists(){
        return File.Exists(Application.persistentDataPath + "/playerUsedSpecialCodes.json");

    }

    public void SaveUsedCodes(){
        File.WriteAllText(Application.persistentDataPath + "/playerUsedSpecialCodes.json", JsonConvert.SerializeObject(UsedCodes));
    }

    public bool CodeExists(string code){
        return SpecialCodes.ContainsKey(code);
    }
    public bool CheckUsedCode(string code){
        return UsedCodes[code];
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }
}
