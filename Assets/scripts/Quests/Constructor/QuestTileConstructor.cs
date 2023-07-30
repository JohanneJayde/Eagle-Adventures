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

public class QuestTileConstructor : MonoBehaviour
{

    /*
     * CreateTile Creates a GameObject that is a Quest Tile. It instantiates a new instance of the Prefab
     * Quest Tile. It then calls Render method will the parameter being the quest you want to create the tile for
     *
     */

    public static GameObject GetTile(Quest quest, GameObject parent)
    {
        GameObject QuestTile = SetTileDetails(quest, parent);
  
     //   OpenDetailsScreen(QuestTile);

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
    public static List<GameObject> CreateTiles(IEnumerable<Quest> Quests, GameObject parent)
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in Quests)
        {
            QTiles.Add(GetTile(quest, parent));
        }

        return QTiles;
    }

    /* 
     * CreateAllTiles creates a List of Quest Tiles GameObjects for Quests registered within the QuestManager
     * This is handy when for when there is a need to create a view of all the quests within a screen
     */
    public List<GameObject> CreateAllTiles(GameObject parent)
    {

        List<GameObject> QTiles = new List<GameObject>();

        foreach (Quest quest in QuestManager.Instance.Quests)
        {
            QTiles.Add(GetTile(quest, parent));

        }

        return QTiles;
    }

    public static GameObject SetTileDetails(Quest quest, GameObject parent){
        GameObject QuestTile = Instantiate((GameObject)Resources.Load("Prefabs/Components/Quest Tile"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        QuestTile.transform.SetParent(parent.transform, false);
        QuestTile.GetComponent<QuestTile>().RenderTile(quest);
        return QuestTile;
    }

}