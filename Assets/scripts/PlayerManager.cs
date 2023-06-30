using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

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
        public PlayerData()
        {

        }

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
     */

    public void CreateNewPlayer(string name="Eagle Scout",string house="Explorer")
    {
        this.Name = name;
        this.House = house;
        this.Level = 0;
        this.CoinCount = 0;
        this.ExpEarned = 0;
        SavePlayerInfo();
    }

    /*
     * LoadExistingPlayer returns an existing player's data from playerInfo.json that is stored in the persistent data path of
     * the device. From there, SendDataToPlayerManager() unwraps this data and sets them to the Properties of the PlayerManager instance
     * for use in the app.
     */

    public void LoadExistingPlayer()
    {
        
        PlayerData data = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(Application.persistentDataPath + "/playerInfo.json"));
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
        this.CoinCount = pData.level;
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

    }

    /*
     * Start checks if the player has existing data using checkPlayerData(), if it does, then we can load it using
     * LoadExistingPlayer() and that will re-initialize all of the PlayerManager's properties
     */

    void Start()
    {

        if(CheckPlayerData())
            PlayerManager.Instance.LoadExistingPlayer();

    }

    /*
     * checkPlayerData() checks for the existence of playerInfo.json in the persistent data storage.
     * true if it exists and false if it doesn't. Alternativly, a flag can be set in PlayerPrefs
     */

    public bool CheckPlayerData()
    {
        return File.ReadAllText(Application.persistentDataPath + "/playerInfo.json") != null;
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
     * This is mostly for testing purposes like new user only features. However, a reset account
     * feature could be added in the future
     */
    public void DeleteSaveData()
    {
        File.Delete(Application.persistentDataPath + "/playerInfo.json");
    }
}
