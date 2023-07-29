using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using UnityEngine.Events;

/*
 * PlayerMangager stores information regarding the player's info.
 * This includes storing the current info, saving it, and updating it
 * The goal was ultize the Singleton pattern and make this avaiable to other components of the app
 */

public class PlayerManager : MonoBehaviour
{
    /*
     * PlayerData class is used as a intermediary step between loading and storing User data onto disk
     * It has the same fields that are used for player data storage. The reason for it existence can be found
     * in the savePlayerData() method
     */
    public class PlayerData
    {
        public string name;
        public string house;
        public int level;
        public int coinCount;
        public int expEarned;

        /*
         * PlayerData EVC takes in a PlayerManger and reflects all of its properties into the fields of PlayerData 
         */
        public PlayerData(PlayerManager p)
        {
            name = p.Name;
            house = p.House;
            level = p.Level;
            coinCount = p.CoinCount;
            expEarned = p.ExpEarned;
        }
        /*
         * Empty contructor is needed due to how LoadExistingPlayer() is done. A PlayerData object cannot
         * be created using the Json deserialization unless there is an empty constuctor. Without this,
         * it will try and call the constructor with @param PlayerManager will cause NullPointerException.
         */
        public PlayerData() {}

    }


    /*
     * Properties for the user that we want to keep track of throughout the app.
     */

    public string Name { get; set; }
    public string House { get; set; }
    public int Level { get; set; }
    public int CoinCount { get; set; }
    public int ExpEarned { get; set; }

    /* 
     * PlayerProgress keeps track of a players progress. A Dictionary stores each Quest IDs as the key and a boolean value indicating if the player
     * has completed it
     */
    public Dictionary<string, bool> PlayerProgress { set; get; }

    /*
     * onLevelUp is an event that will invoke all of the methods subscribed to it when it is invoked. This is used for when its time to update the quest
     * tiles so they unlock and lock at the correct times (see QuestTileSupplier for more info on the logic).
     */
    public UnityEvent onLevelUp;

    /*
     * onStatUpdate triggers events that need to happen when a Player's stats chanage.
     *
     */
    public UnityEvent onStatUpdate;

    /*
     * Singleton logic
     */
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Cannot exist");
            return _instance;
        }

    }

    /*
     * createNewPlayer sets the PlayerManager properties to default values except for name and house
     * which can be set by the user inputs. If the user doesn't put any input, there are default values
     * for them.
     * Once the data has been created, it will be stored as a JSON file and saved into the persistent storage.
     * Logic for how it works is explained in savePlayerInfo()
     * 
     * Also calls CreateStats() which loads in the user's quest progress
     */
    public void CreateNewPlayer(string name="Eagle Scout",string house="Explorer")
    {
        this.Name = name;
        this.House = house;
        this.Level = 0;
        this.CoinCount = 0;
        this.ExpEarned = 0;
        CreateStats();
        SavePlayerInfo();
    }

    /*
     * LoadExistingPlayer returns an existing player's data from playerInfo.json and playerProgress.json that is stored in the persistent data path of
     * the device. From there, SendDataToPlayerManager() unwraps this data and sets them to the Properties of the PlayerManager instance
     * for use in the app.
     */
    public void LoadExistingPlayer()
    {
        PlayerData data = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(Application.persistentDataPath + "/playerInfo.json"));
        PlayerProgress = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(Application.persistentDataPath + "/playerProgress.json"));
        SendDataToPlayerManager(data);
    }

    /*
     * sendDataToPlayerManager takes in a PlayerData object and unwraps it's fields to send to the actual PlayerManager properties.
     */
    public void SendDataToPlayerManager(PlayerData pData)
    {
        this.Name = pData.name;
        this.House = pData.house;
        this.Level = pData.level;
        this.CoinCount = pData.coinCount;
        this.ExpEarned = pData.expEarned;
    }

    /*
     * A new PlayerData object is created and uses the PlayerManager's properties to set it's own fields.
     * It is then serialized into a string representation of a JSON file. From there, it will be written
     * into playerInfo.json which is stored into the persistent data path of the device.
     * NOTE: playerInfo.json will either be created or overwritten in this method.
     * 
     */
    public void SavePlayerInfo()
    {
        PlayerData data = new PlayerData(this);
        File.WriteAllText(Application.persistentDataPath + "/playerInfo.json", JsonConvert.SerializeObject(data));
        File.WriteAllText(Application.persistentDataPath + "/playerProgress.json", JsonConvert.SerializeObject(PlayerProgress));

    }

    /*
     * Start checks if the player has existing data using checkPlayerData(), if it does, then we can load it using
     * LoadExistingPlayer() and that will re-initialize all of the PlayerManager's properties
     */
    void Start()
    {
        if(CheckPlayerData())
        {
            Debug.Log("Player Loaded");
            LoadExistingPlayer();
            Debug.Log(PlayerManager.Instance);
        }
    }

    /*
     * checkPlayerData() checks for the existence of playerInfo.json in the persistent data storage.
     * true if it exists and false if it doesn't. Alternativly, a flag can be set in PlayerPrefs
     */
    public bool CheckPlayerData()
    {
        return File.Exists(Application.persistentDataPath + "/playerInfo.json");
    }

    /*
     * ToString just returns the string representation of PlayerManager. This is only used for
     * debug purposes. Overrides ToString in Object class
     */
    override
    public string ToString()
    {

        return "Name: " + this.Name + "\nHouse: " + this.House
        + "\nLevel: " + this.Level + "\nCoin Count: " + this.CoinCount
        + "\nExp Earned: " + this.ExpEarned;
    }

    /*
     * Creates a Dictionary to store a Player's quest progress.
     * It reads QuestManager's master list of Quests to ensure that it will always be up to datae.
     * NOTE: This logic will change when Quest reading becomes dynamic. 
     */
    public void CreateStats()
    {
        PlayerProgress = new Dictionary<string, bool>();

        foreach (var quest in QuestManager.Instance.Quests)
        {
            PlayerProgress.Add(quest.QuestID, false);
        }
    }
    /*
     * sets the instance to this.
     */
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    /*
     * DeleteSaveData deletes all the player data on a user's device by deleting the playerInfo.json
     * and playerProgress.json. Because the player is loaded as soon as the app starts, we also need
     * to reset all the properties of the PlayerManager to clear them. PlayerPrefs are also deleted.
     */
    public void DeleteSaveData()
    {
        File.Delete(Application.persistentDataPath + "/playerInfo.json");
        File.Delete(Application.persistentDataPath + "/playerProgress.json");
        Name = null;
        House = null;
        Level = 0;
        CoinCount = 0;
        ExpEarned = 0;
        PlayerProgress = new Dictionary<string, bool>();

        PlayerPrefs.DeleteAll();
        Debug.Log("Successfully deleted user player data");
    }
    
    /*
     * UpdateStats updates the stats the given Quest and does the following:
     * Adds the ExpEarned and CoinRewards to the Player's respective properties
     * Levels up the player if they have enought Exp
     * Updates PlayerProgres to make the Quest key's value true
     * Saves the updated stats to disk so won't be lost if app is closed
     */
    // public void UpdateStats(Quest quest)
    // {
    //     ExpEarned += quest.ExpEarned;
    //     CoinCount += quest.CoinsReward;

    //     if(CheckLevel(ExpEarned)){
    //         SetLevel(Level + 1);
    //     }
    //     PlayerProgress[quest.QuestID] = true;
    //     SavePlayerInfo();

    //     onStatUpdate?.Invoke();

    // }
    /**
     * CheckLevel returns true if a player has reached the Exp amount of the level that is 1 above the one the player is at.
     */
    // public bool CheckLevel(int totalXP)
    // {
    //     if (totalXP >= LevelData.Levels[Instance.Level + 1])
    //         return true;
        
    //     return false;
    // }
    /*
     * Setlevel sets the Player's level to the level specified by the level param. It will also invoke the onLevelUp event which notifies all the subscribers
     * to run.
     */
    public void SetLevel(int level){
            Level = level;
            onLevelUp?.Invoke();

            Debug.Log("LEVEL UP!");
    }
}
