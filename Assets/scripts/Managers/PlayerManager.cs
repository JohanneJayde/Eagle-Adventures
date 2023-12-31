using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using UnityEngine.Events;
using System.Linq;

/*
 * PlayerMangager stores information regarding the player's info.
 * This includes storing the current info, saving it, and updating it
 * The goal was ultize the Singleton pattern and make this avaiable to other components of the app
 */

public class PlayerManager : MonoBehaviour
{

    /*
     * Properties for the user that we want to keep track of throughout the app.
     */

    public string Name { get; set; }
    public string Group { get; set; }
    public int Level { get; set; }
    public int CoinCount { get; set; }
    public int ExpEarned { get; set; }

    /* 
     * PlayerProgress keeps track of a players progress. A Dictionary stores each Quest IDs as the key and a boolean value indicating if the player
     * has completed it
     */
    public Dictionary<string, bool> PlayerProgress { set; get; }

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
     * createNewPlayer sets the PlayerManager properties to default values except for name and group
     * which can be set by the user inputs. If the user doesn't put any input, there are default values
     * for them.
     * Once the data has been created, it will be stored as a JSON file and saved into the persistent storage.
     * Logic for how it works is explained in savePlayerInfo()
     * 
     * Also calls CreateStats() which loads in the user's quest progress
     */
    public void CreateNewPlayer(string name="Eagle Scout",string group="A")
    {
        this.Name = name;
        this.Group = group;
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
        Debug.Log(PlayerManager.Instance);
    }


    /*
     * Updates the new Quest if it doesn't exist within the existing quests 
     */
    public void UpdateQuests(){
        List<Quest> newQuests = QuestManager.Instance.Quests.Where(quest =>
            {
            return PlayerProgress.ContainsKey(quest.QuestID) == false;
            }
        ).ToList();

        if(newQuests.Count == 0){
            Debug.Log("No New Quests Found");

            return;
        }

        newQuests.ForEach(quest => {
            Debug.Log("New Quest Found: " + quest.QuestID);
            PlayerProgress.Add(quest.QuestID, false);
        });

        SavePlayerInfo();

    }

    /*
     * sendDataToPlayerManager takes in a PlayerData object and unwraps it's fields to send to the actual PlayerManager properties.
     */
    public void SendDataToPlayerManager(PlayerData pData)
    {
        this.Name = pData.name;
        this.Group = pData.group;
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
        if(CheckPlayerData()){
            LoadExistingPlayer();
            Debug.Log("Player Loaded");
        }
        else{
            Debug.Log("Player Data not loaded");
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

        return "Name: " + this.Name + "\nGroup: " + this.Group
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
        Group = null;
        Level = 0;
        CoinCount = 0;
        ExpEarned = 0;
        PlayerProgress = new Dictionary<string, bool>();

        PlayerPrefs.DeleteAll();
        Debug.Log("Successfully deleted user player data");
    }
    
    public void UpdateCoins(int coins){

        CoinCount = coins;
        Debug.Log("Coins updated: " + CoinCount.ToString());
        SavePlayerInfo();

    }

    public void UpdateExp(int exp){
        ExpEarned += exp;
        Debug.Log("Exp updated: " + ExpEarned.ToString());

        SavePlayerInfo();

    }

    public void UpdateQuestDone(string questID){
        PlayerProgress[questID] = true;
        SavePlayerInfo();
    }

    public void UpdateLevel(int level){
        Level = level;
                SavePlayerInfo();

    }

}
