using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestScreen : MonoBehaviour
{

    public List<Quest> Quests;
    public GameObject Tiles;

    // Start is called before the first frame update
    void Start()
    {
        RenderQuestTiles();

    }

    public void RenderQuestTiles(){
        foreach(var quest in Quests){
            GameObject tile = Instantiate(Resources.Load("Quest Tile"),Tiles.transform, false) as GameObject;
            tile.name = quest.Title;
            tile.GetComponent<QuestTile>().RenderTile(quest);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuests(string campaign){
        Quests = QuestManager.Instance.Quests.Where((quest) => {return quest.Session == campaign;}).ToList();
    }

}
