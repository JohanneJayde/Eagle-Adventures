using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    /*
     * PlayerData class is used as a intermediary step between loading and storing User data onto disk
     * It has the same fields that are used for player data storage. The reason for it existence can be found
     * in the savePlayerData() method
     */

        public string name;
        public string group;
        public int level;
        public int coinCount;
        public int expEarned;

        /*
         * PlayerData EVC takes in a PlayerManger and reflects all of its properties into the fields of PlayerData 
         */
        public PlayerData(PlayerManager p)
        {
            name = p.Name;
            group = p.Group;
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
