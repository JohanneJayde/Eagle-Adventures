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

    }

    public void RenderQuestTiles(){
        QuestConstructor.ConstructQuests(Quests, Tiles, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuests(string campaign){

        ClearTiles(Tiles);

        Quests = QuestManager.Instance.Quests.Where((quest) => {

        return quest.Session == campaign;
        }).ToList();

        RenderQuestTiles();

    }

    public void ClearTiles(GameObject tiles){
         foreach (Transform child in tiles.transform) {
                Destroy(child.gameObject);
            }
    }

}
