using UnityEngine;
using CsvHelper;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{

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
        public Uri CanvasURL { get; set; }

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

    public IEnumerable<Quest> quests { get; set; }


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

        using var reader = new StreamReader(@"Assets/data/Quests.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        quests = csv.GetRecords<Quest>().ToList();

    }

    /*
     * Returns the given quest object f
     */
    public Quest FetchQuestInfo(string QuestID)
    {
        return (Quest)quests.Single((quest) => quest.QuestID.Equals(QuestID));
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
        LoadQuests();
    }
}
