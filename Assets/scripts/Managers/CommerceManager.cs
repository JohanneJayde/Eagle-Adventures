using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CommerceManager : MonoBehaviour
{
    /*
    * Singleton logic
    */
    private static CommerceManager _instance;
    public Dictionary<string, int> SpecialCodes {get; set;}
    public List<string> UsedCodes {get; set;}
    public struct SpecCode{
        public string code;
        public int amount;
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
        Debug.Log("Loading Json");
        TextAsset json = Resources.Load("Data/SpecialCodes") as TextAsset;
        Debug.Log(json.text);
        List<SpecCode> specCodes = new List<SpecCode>();
        specCodes = JsonConvert.DeserializeObject<List<SpecCode>>(json.text);
        SpecialCodes = new Dictionary<string, int>();
        foreach(var code in specCodes){
            SpecialCodes.Add(code.code, code.amount);
            Debug.Log(code.code + " " + SpecialCodes[code.code]);
        }
        
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
