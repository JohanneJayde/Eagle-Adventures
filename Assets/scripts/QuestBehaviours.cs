using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuestBehaviours : MonoBehaviour
{

    public static void AddBehaviour<T>(GameObject Tile, GameObject screen) where T : TileBehaviour, new() {

        Button button = Tile.GetComponent<QuestTile>().StartButton;
        Tile.AddComponent<T>();

        Tile.GetComponent<TileBehaviour>().SetComponents(button, screen);
        Tile.GetComponent<TileBehaviour>().AddBehaviour();


    }

    public static void AddBehaviourToTiles<T>(List<GameObject> Tiles, GameObject screen) where T : TileBehaviour, new(){

        foreach(var tile in Tiles){
            AddBehaviour<T>(tile, screen);
        }

    }

}
