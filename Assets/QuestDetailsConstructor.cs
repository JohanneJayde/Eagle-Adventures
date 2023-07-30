using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDetailsConstructor : MonoBehaviour
{

    public static GameObject getQuestScreen(Quest quest){
        switch(quest.Type){
            case "Canvas Completed":
                return  Instantiate((GameObject)Resources.Load("Canvas Completed Directions"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

                break;
            case "Physical Code":
                return  Instantiate((GameObject)Resources.Load("Canvas Completed Directions"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

                break;
            case "Short Answer":
                return  Instantiate((GameObject)Resources.Load("Canvas Completed Directions"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

                break;
            case "No code":
                return Instantiate((GameObject)Resources.Load("Canvas Completed Directions"), new Vector2(0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

                break;
            default:
                return null;
        }

    }

}
