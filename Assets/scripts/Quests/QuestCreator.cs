using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestCreator : MonoBehaviour
{

    public List<GameObject> screens;


    public void AddListeners(List<GameObject> tiles){
        foreach(var tile in tiles){
            Debug.Log("Screen assigned");
            AssignScreen(tile);
        }
    }

    public void AssignScreen(GameObject tile){

        Quest quest = tile.GetComponent<QuestTile>().Quest;
        GameObject screen = GetScreen(quest.Type);

        Button startQuest = tile.GetComponentInChildren<Button>();

        startQuest.onClick.AddListener(
           () => { 
            SetUpScreen(quest, screen);
            screen.SetActive(true);
            }
        );


    }

    public void SetUpScreen(Quest q, GameObject screen){
        screen.GetComponent<QuestDetailScreen>().RenderQuest(q);
    }

    public GameObject GetScreen(string type){

        return screens.Where((screen) => {return screen.name == type;}).Single();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
