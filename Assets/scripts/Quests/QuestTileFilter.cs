using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTileFilter : MonoBehaviour
{

    //TODO: QuestTileFilter is meant to filter quests by any field and also sort them in any direciton 

    //QuestTileFilter needs to be built in order to filter and sort quests
    //This will be a seperate object class that takes in a list of Quests and can filter them and return them
    //A key factor is being able to sort them not only within a regular list but to display them as filtered.
    //This involves actually changing the Siblings of each GameObject to reflect the sorted order of the list.

    //Attach a list of GameObjects and then filter them in place or use supplier to create a filtered list.
    //Attach a list of Quests maybe

    //Using Zip OrderBy maybe

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
