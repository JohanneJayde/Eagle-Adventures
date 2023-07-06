using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FileHelpers;

/*
  * Quest class is used to store information of a given quest that was located in the Quests.CSV
  * A Quest object is created via FileHelpers the declarative tags above class declaration mean
  * skip the header row, commas are used to seperate the fields, and ignore the empty lines in file
*/
[IgnoreFirst(1)]
[DelimitedRecord(",")]
[IgnoreEmptyLines()]
public class Quest
{
    /*
     * Properties for a Quest. They are based on the CSV format. A quest MUST have these fields
     * in order to be handled by the app.
     */

    //QuestID is unique
    public string QuestID { get; set; }
    public string Title { get; set; }
    public string LongDescription { get; set; }
    public string ShortDescription { get; set; }
    public int ExpEarned { get; set; }
    public int CoinsReward { get; set; }
    public string Code { get; set; }
    public int LevelRequirement { get; set; }
    public string Theme { get; set; }
    public string CanvasURL { get; set; }

    /*
     * ToString just used for debugging puroses
     */
    override
    public string ToString()
    {
        return $"QuestID : {QuestID} Title : {Title} Level Requirement : {LevelRequirement}";
    }

    /*
     * TO-DO: returns the headers of the quest. 
     */

    public string Headers()
    {
        return
            nameof(QuestID) + ", " +
            nameof(Title);
    }

}