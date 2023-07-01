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
        public string QuestID { get;}
        public string Title { get; }
        public string LongDescription { get; }
        public string ShortDescription { get; }
        public int ExpEarned { get; }
        public int CoinsReward { get;}
        public string Code { get; }
        public int LevelRequirement { get;}
        public string Theme { get; }
        public Uri CanvasURL { get; }

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
        quests = csv.GetRecords<Quest>();

    }

    /*
     * 
     */
    public void RenderQuest(int QuestID)
    {

    }

    private void Awake()
    {
        LoadQuests();
    }
}
