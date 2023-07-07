using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Reasoning: If we are to have multiple places where Quest tiles are needed, then we should have a way
 * to give them a set of quests that they can filter and also will update when it needs to.
 *
 * Proprosed Flow:
 * This script is attached to any screen that needs to render a list of quests.
 * It will clone a list of quest Tiles and 
 *
 */
public class QuestSupllier : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> QuestTiles = new List<GameObject>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
