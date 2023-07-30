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
        QuestTileSupplier.CreateTiles(Quests, Tiles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuests(string campaign){
        Quests = QuestManager.Instance.Quests.Where((quest) => {return quest.Session == campaign;}).ToList();
    }

}
