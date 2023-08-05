using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * LevelData stores a Dictionary for the XP system.
 */
public class GameData : MonoBehaviour
{

    public class LevelRewards{
        public int Exp {get; set;}
        public int Coins {get; set;}
    }

    /*
     * A Dictionary stores the levels with the XP amount that the player needs to reach before a level up can
     * be granted
     */
    public static Dictionary<int, int> PlayerLevels = new Dictionary<int, int> {
        {0,0},
        {1,100 },
        {2, 250 },
        {3, 400 },
        {4, 500 },
        {5, 700 },
        {6, 1000 },
        {7, 1500 },
        {8, 2000 },
        {9, 2200 },
        {10, 10000 },
        };

    public static Dictionary<int, LevelRewards> Rewards = new Dictionary<int, LevelRewards>{
        {1,new LevelRewards{Exp = 20, Coins = 10}},
        {2,new LevelRewards{Exp = 50, Coins = 25}},
        {3,new LevelRewards{Exp = 75, Coins = 50}},
        {4,new LevelRewards{Exp = 100, Coins = 75}},
        {5,new LevelRewards{Exp = 125, Coins = 100}},
        {6,new LevelRewards{Exp = 150, Coins = 150}},
    };

}
