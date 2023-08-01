using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class BehaviourBuilder : MonoBehaviour
{
    public static void AddBehaviour<T>(Button button, GameObject screen) where T : ButtonBehaviour, new() {

        ButtonBehaviour behaviour = new T();
        behaviour.AddBehaviour(button, screen);

    }

    public static void AddBehaviourToTiles<T>(List<GameObject> Tiles, GameObject screen) where T : ButtonBehaviour, new(){

        foreach(var tile in Tiles){
            Button button = tile.GetComponent<QuestTile>().StartButton;
            AddBehaviour<T>(button, screen);
        }

    }

}
