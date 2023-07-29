using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * LevelData stores a Dictionary for the XP system.
 */
public class LevelData : MonoBehaviour
{
    /*
     * A Dictionary stores the levels with the XP amount that the player needs to reach before a level up can
     * be granted
     */
    public static Dictionary<int, int> Levels = new Dictionary<int, int> {
        {0,0},
        {1,100 },
        {2, 250 },
        {3, 400 },
        {4, 500 },
        {5, 1000 } };

}
