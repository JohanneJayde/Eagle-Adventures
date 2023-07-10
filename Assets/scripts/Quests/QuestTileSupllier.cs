using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.UI;



/*
 * QuestTileSuuplier supplies quest tiles to the any part of the app requests. 
 * It does this loading in a prefab for the quest tile and attaching a Quest
 * to it. Then it applies it's functionality, including its ability to open
 * and display it's info on the details screen and update itself when a level up occurs.
 *
 */

//QuestTileFitler needs to be built in order to filter and sort quests
//This will be a seperate object class that takes in a list of Quests and can filter them and return them
//A key factor is being able to sort them not only within a regular list but to display them as filtered.
//This involves actually changing the Siblings of each GameObject to reflect the sorted order of the list.

public class QuestTileSupllier : MonoBehaviour
{


    /*
    Keep a dictionary holding lists of game object quest tiles based on level,
    on level up, call render on the level that the player has reached to unlock them
    then each time it will incremenet
    */

    /*
     *TileLevelSet stores all quest tiles active in the app. It will be used to update their info if they need
     * need to be unlocked after a player levels up
     */
    public Dictionary<int, List<GameObject>> TileLevelSet {get; set;}

    /*
     * CreateTile Creates a GameObject that is a Quest Tile. It instantiates a new instance of the Prefab
     * Quest Tile. It will also set the QuestTile Quest property to the quest it was sent as a param.
     * Using that Quest object, it will call render() which makes the tile dispaly the correct info.
     * It will apply listereners last
     *
     * NOTE: Opening the canvas app is not considered as part of the listeners because it is apart of the 
     * Quest info and doesn't impact encapsulation if done inside Render method
     */

    public GameObject CreateTile(Quest quest)
    {
        GameObject QuestTile = Instantiate((GameObject)Resources.Load("Prefabs/QuestTile"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        QuestTile.GetComponent<QuestTile>().Quest = quest;
        QuestTile.GetComponent<QuestTile>().Render();

        ApplyEvents(QuestTile);

        return QuestTile;
    }

    /*
     * ApplyListener adds the GameObject as a subscriber to the OnLevelUp event from the PlayerManager.
     * This means it will unlock itself if the player level reaches it's level requirement.
     *
     * NOTES: There may be no need to have the Quest be a property of QuestScreen. This will be either be changed
     * or not after review
     */
    public void ApplyEvents(GameObject tile){
        PlayerManager.Instance.onLevelUp.AddListener(tile.GetComponent<QuestTile>().SetLockStatus);

    }
    /* CreateTiles simply calls CreateTiles on a list of Quests given as a IEnumerable.
     * This allows for the creation of a list of any quests, so using this in conjuction with a filter method
     * is useful. It returns a List of GameObjects that have already have their functionality added.
     *
     * Fixes: Currently, this method does not support setting the parent GameObject of the Quest Tiles.
     * This will be fixed because there is no reason to create GameObject without adding setting the parent
     * (they will just sit there without being displayed)
     */
    public List<GameObject> CreateTiles(IEnumerable<Quest> Quests)
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in Quests)
        {
          
            QTiles.Add(CreateTile(quest));

        }

        return QTiles;
    }

    /* 
     *CreateAllTiles creates a List of Quest Tiles GameObjects for Quests registered within the QuestManager
     * This is handy when for when there is a need to create a view of all the quests within a screen
     *
     */
    public List<GameObject> CreateAllTiles()
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in QuestManager.Instance.Quests)
        {
          
            QTiles.Add(CreateTile(quest));

        }

        return QTiles;
    }



}
