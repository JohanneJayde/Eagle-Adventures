using UnityEngine;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using FileHelpers;

public class QuestManager : MonoBehaviour
{
[IgnoreFirst(1)]
[DelimitedRecord(",")]
[IgnoreEmptyLines()]
    public class Quest
    {
        public string QuestID { get; set; }
        public string Title { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int ExpEarned { get; set; }
        public int CoinsReward { get; set; }
        public string Code { get; set; }
        public int LevelRequirement { get; set; }
        public string Theme { get; set; } 
        public string CanvasURL { get; set; }

        override
        public string ToString()
        {
            return $"QuestID : {QuestID} ";
        }

        public string Headers()
        {
            return
                nameof(QuestID) + ", " +
                nameof(Title);
        }
         
    }

    public IEnumerable<Quest> Quests { get; set; }


    /*
     * Singleton logic
     */
    private static QuestManager _instance;

    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }

    // Use this for initialization
    void Start()
    {
    }

    /*
     * SetUpConfig reads the list of quests into the IEnumerable quests 
     */

    public void LoadQuests()
    {

        var engine = new FileHelperEngine<Quest>();

        Quests = engine.ReadFileAsList(Application.persistentDataPath + "/Quests.csv").ToList();

       // quests = engine.ReadFileAsList(@"Assets/data/Quests.csv").ToList();


        Debug.Log(Quests.Count());

        //using var reader = new StreamReader(Application.persistentDataPath + "/Quests.csv");

        //using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        //quests = csv.GetRecords<Quest>().ToList();

    }

    /*
     * Returns the given quest object f
     */
    public Quest FetchQuestInfo(string QuestID)
    {
        return (Quest)Quests.Single((quest) => quest.QuestID.Equals(QuestID));
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);

        if (File.Exists(Application.persistentDataPath + "/Quests.csv"))
        {
            Debug.Log("New Quests Loaded");
            TextAsset file = Resources.Load("Quests") as TextAsset;

            File.WriteAllText(Application.persistentDataPath + "/Quests.csv", file.text);

        }

        Debug.Log(File.ReadAllText(Application.persistentDataPath + "/Quests.csv"));

        LoadQuests();
    }
}
