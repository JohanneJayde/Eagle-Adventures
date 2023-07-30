using UnityEngine;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using FileHelpers;
using UnityEngine.Events;


/*
 * QuestManager is used to load and process quests that it has recieved from a given csv file.
 * The CSV file must be processed correctly in order for this script to function properly. A common
 * use of this script is to let other parts of the app query for certain Quests and return information
 * about them for rendering purposes
 * 
 * @Nuget: FileHelpers
 */

public class QuestManager : MonoBehaviour
{

    /*
     * Quests Property stores all the quests in the CSV file. It is of type IEnumerable to support LINQ operations
     * and for preformance reasons
     */

    public List<Quest> Quests { get; set; }

    public GameObject QuestScreen;
   
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

    /*
     * LoadQuests is used to load the acutal data from the CSV file into the application
     * It utilizes FileHelperEngine to parse csv rows and convert it into Quests list
     * 
     * For complicated reasons, it is reading the copied CSV file that is stored in the app's
     * persistent data path instead of from the Assets/Data directory or from the Assets/Resources folder
     */

    public void LoadQuests(List<Quest> quests)
    {
        this.Quests = quests;
    }

    public void SetRewards(){

        Quests.ForEach(quest => {
                quest.CoinRewards = GameData.Rewards[quest.Level].Coins;
                quest.ExpRewards = GameData.Rewards[quest.Level].Exp;

        });

    }

    /*
     * Given a QuestID, FetchQuestInfo returns the associated Quest object containing all of its
     * information for rendering purposes
     * 
     * It is using LINQ Single() method is used to return single Quest that satisfies the Function
     * A Lamda Expression is used in place of Function
     */
    public Quest FetchQuestInfo(string QuestID)
    {
        return (Quest)Quests.Single((quest) => quest.QuestID.Equals(QuestID));
    }

    private void Start()
    {

    }

    /*
     * Awake sets up the single Instance of QuestManager and also reads the Quest.CSV from Resources folder
     * into the Application's persistence data path. This is due to issues that occured while trying to access
     * files using a platofrms native file path. This may be fixed in the future. This is also assuming that the
     * Quest.CSV is static when it will eventually become dynamic in later builds.
     */

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);

        TextAsset file = Resources.Load("Data/Quests") as TextAsset;
        File.WriteAllText(Application.persistentDataPath + "/Quests.csv", file.text);

    }
}
