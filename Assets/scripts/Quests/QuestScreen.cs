using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestScreen : MonoBehaviour
{


    public List<Quest> Quests;
    public GameObject TilesContainer;
    public List<GameObject> Tiles;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RenderQuestTiles(){
        Tiles = QuestConstructor.ConstructQuests(Quests, TilesContainer);
        QuestBehaviours.AddBehaviourToTiles<ExitOnClickBehaviour>(Tiles, gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuests(string campaign){

        ClearTiles(TilesContainer);

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
