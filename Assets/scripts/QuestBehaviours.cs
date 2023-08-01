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

        T behaviour = new T{Button = button, Screen = screen};

        behaviour.AddBehaviour();

        Tile.AddComponent<T>();


    }

    public static void AddBehaviourToTiles<T>(List<GameObject> Tiles, GameObject screen) where T : TileBehaviour, new(){

        Tiles.ForEach(tile => AddBehaviour<T>(tile, screen));

    }

}
