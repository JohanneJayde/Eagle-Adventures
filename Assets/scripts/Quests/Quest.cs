using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

public string QuestID {set; get;}
public string Code {set; get;}
public string Description {set; get;}
public string Directions {set; get;}
public int Level {set; get;}
public string Session {set; get;}
public string Question {get; set;}
public string ShortAnswer {set; get;}
public string Theme {set; get;}
public string TimeCompletion {set; get;}
public string Title {set; get;}
public string Type {set; get;}
public int CoinRewards {get; set;}
public int ExpRewards {get; set;}


public override string ToString(){
    return "QuestID: " + QuestID + ", Short Answer: " + ShortAnswer; 
}

}
