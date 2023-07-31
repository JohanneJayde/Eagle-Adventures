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
    public List<SpecCode> SpecialCodes {get; set;}
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
        SpecialCodes = JsonConvert.DeserializeObject<List<SpecCode>>(json.text);
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
