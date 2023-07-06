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
        {1,50 },
        {2, 100 },
        {3, 150 },
        {4, 200 },
        {5, 250 } };

}
