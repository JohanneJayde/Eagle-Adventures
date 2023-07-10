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

 /*
  * Possible improvements: 
  * A constructor may be added to specify the Quest Screen so someone can change where the quest tiles open
  * instead of having to set the QuestScreen Property.
  * 
  * There is a stipulation in Unity that you cannot attach a GameObject to a Prefab. This causes problems
  * as the QuestTileSupplier need not know the QuestScreen itself as it's the Quest Tiles job to open it up
  * However, since this cannot happen, the QuestScreen reference lives here. This could be beneficial as it allows
  * Quest Tiles to open up different Screens depending on what the programmer needs. 
  */ 

//QuestTileFitler needs to be built in order to filter and sort quests
//This will be a seperate object class that takes in a list of Quests and can filter them and return them
//A key factor is being able to sort them not only within a regular list but to display them as filtered.
//This involves actually changing the Siblings of each GameObject to reflect the sorted order of the list.

public class QuestTileSupllier : MonoBehaviour
{

    //Holds a reference to Quest Screen that the quest tile can open to display it's information
    public GameObject QuestScreen;

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
     * ApplyListener adds in events a Gameobject, more specifically, a quest tile.
     * It gets the button component of the quest tile and adds an onClick event to open the details screen
     * It will send in it's Quest property to display it's info onto the screen if it's clicked
     * It will also make the SetLockStatus method of the QuestTile component in the tile fire if OnLevelUp
     * UnityEvent is invoked. This is important as this makes all tiles observe the level up so they update
     * themselves at the correct time.
     *
     * NOTES: There may be no need to have the Quest be a property of QuestScren. This will be either be changed
     * or not after review
     */
    public void ApplyEvents(GameObject tile){

        tile.GetComponent<Button>().onClick.AddListener(() => RenderDetails(tile.GetComponent<QuestTile>().Quest));
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

    /*
    * Once a Quest has been rendered, it must be able to be tapped and link to a screen that shows off its full information
    * This is done by first setting the details script's Quest Property to the Quest that we want to render info for.
    * It calls SetScreenDetails on the QuestScren to display it's info and activates the screen to show off the info.
    */
    public void RenderDetails(Quest quest)
    {

        QuestScreen.GetComponent<QuestScreen>().SetScreenDetails(quest);
        QuestScreen.SetActive(true);
    }

}
