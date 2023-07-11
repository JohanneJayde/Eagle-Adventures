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
 * to it. The Prefab has an attached script called QuestTile which has a method called
 * SetQuest. SetQuest will set up the Quest Tile so it displays the right info and also
 * has its functionality ready.
 */

public class QuestTileSupplier : MonoBehaviour
{

    /*
    Keep a dictionary holding lists of game object quest tiles based on level,
    on level up, call render on the level that the player has reached to unlock them
    then each time it will incremenet

    This may add overhead if QuestManager manages the list
    */

    //This is parent GameObject where quests will be attached to.
    public GameObject Parent {get; set;}

    public QuestTileSupplier(GameObject parent){

        Parent = parent;

    }

    /*
     * CreateTile Creates a GameObject that is a Quest Tile. It instantiates a new instance of the Prefab
     * Quest Tile. It then calls Render method will the parameter being the quest you want to create the tile for
     *
     */

    public GameObject CreateTile(Quest quest)
    {
        GameObject QuestTile = Instantiate((GameObject)Resources.Load("Prefabs/QuestTile"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        QuestTile.transform.SetParent(Parent.transform, false);
        QuestTile.GetComponent<QuestTile>().SetQuest(quest);

        return QuestTile;
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
     * CreateAllTiles creates a List of Quest Tiles GameObjects for Quests registered within the QuestManager
     * This is handy when for when there is a need to create a view of all the quests within a screen
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
