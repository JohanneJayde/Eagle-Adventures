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
    public IEnumerable<Quest> QuestsToUnlock { get; set; }

    /*
        QuestLevelSet organizes the quests into lists by level. This comes in handle when it comes to
        unlocking quests. When the player loads in, their level will be read. Using their level,
        we can unlock all the quest lower than or equal to it. Consequently, leveling happens by 1,
        so when it's time to unlock on level up, we only need to look at the quests set at one level
        upbove the user's level. There is no need to scan through the levels below or above that one.
        So we retrieve the next level quests and unlock them without adding extra time scanning.
        The prcoess will be as follows:
        Scan entire CSV to serialize into master list of quests (scan 1)
        Organize quests into QuestLevelSet object (scan 2)
        Unlock quest that are lower or at current level
        as you level up, access the current level + 1 and unlock them.

        UpdateLevel -> set QuestsToUnlock => call update on all tiles
        if tile level is at level, it will unlock itself and remove event listener.
        Other than quests will keep themselves locked

        on start, quests tiles containing quests below user level will not have listener applied to them.


    */
    public Dictionary<int, List<Quest>> QuestLevelSet {get; set;}

    public QuestTileSupllier Supplier;

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

    public void LoadQuests()
    {

        var engine = new FileHelperEngine<Quest>();
        Quests = engine.ReadFileAsList(Application.persistentDataPath + "/Quests.csv").ToList();

    }

    /*
     * Contain a list of locked Quests. That way you do not have to constantly iterate over the unlocked quest t
     * 
     */
 
    public void UpdateLockedQuest()
    {

        QuestsToUnlock = QuestLevelSet[PlayerManager.Instance.Level + 1];

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

    public void CreateQuestSet(){
        
        foreach(Quest quest in Quests){
            QuestLevelSet[quest.LevelRequirement].Add(quest);
            Debug.Log($"KEY: {quest.LevelRequirement} - QuestID: {quest.QuestID}");

        }

    }


    private void Start()
    {

        QuestsToUnlock = new List<Quest>();
        QuestLevelSet = new Dictionary<int, List<Quest>>();

        foreach(int key in LevelData.Levels.Keys){
            QuestLevelSet.Add(key, new List<Quest>());
        }

        Supplier = new QuestTileSupllier();
        Supplier.QuestScreen = QuestScreen;

        LoadQuests();
        CreateQuestSet();

        QuestsToUnlock = QuestLevelSet[PlayerManager.Instance.Level + 1];
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
