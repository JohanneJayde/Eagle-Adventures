using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * PlayerMangager stores information regarding the player's info.
 * This includes storing the current info, saving it, and updating it
 * The goal was ultize the Singleton pattern and make this avaiable to other components of the app
 */

public class PlayerManager : MonoBehaviour
{

    /*
     * 
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
                Debug.Log("hi");
            return _instance;
        }

    }

    /*
     * createNewPlayer creates a new playerData object with the given name and house
     * Once the data has been created, it will be stored as a JSON file and into the PlayerPref
     * under playerInfo key. This allows us to keep the data persistent between sessions
     * Alternativly. we can store this into an offshore JSON file
     */

    public void createNewPlayer(string name="Eagle Scout",string house="Explorer")
    {
        this.Name = name;
        this.House = house;
        this.Level = 0;
        this.CoinCount = 0;
        this.ExpEarned = 0;
    }

    /*
     * returnExistingPlayer sets the playerData field in the PlayerManger as the data that has been found
     * to already exist on the device.
     */

    public void ReturnExistingPlayer()
    {
        PlayerManager p = JsonUtility.FromJson<PlayerManager>(PlayerPrefs.GetString("playerInfo", "john"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool checkPlayerData()
    {
        return this.Name != null;
    }

    override
    public string ToString()
    {

        return "Name: " + this.Name + "\nHouse: " + this.House
        + "\nLevel: " + this.Level + "\nCoin Count: " + this.CoinCount
        + "\nExp Earned: " + this.ExpEarned;
    }

    private void Awake()
    {
        _instance = this;
    }
}
