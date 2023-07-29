using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Threading.Tasks;
/*
 * FirebaseReader is used to read from the firebase realtime database. It has been set up to
 * read from the "quest" branch. It will uses a FirebaseConverter to deseralize the data into
 * quest objects for use in the app.
*/
public class FirebaseReader : MonoBehaviour {

    public GameObject titleScreen;

    public void GetQuestData(){

    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    reference
        .Child("Quests")
        .GetValueAsync().ContinueWithOnMainThread(task => {
        if (task.IsFaulted) {
            Debug.Log("failed");

        }
        else if (task.IsCompleted) {
            DataSnapshot snapshot = task.Result;

            FirebaseConverter<Quest> converter = new FirebaseConverter<Quest>();
            
            List<Quest> quests = converter.Deserialize(snapshot);

            gameObject.SetActive(false);
            titleScreen.SetActive(true);
            QuestManager.Instance.LoadQuests(quests);


            foreach(var quest in quests){
                Debug.Log(quest.Title);
            }
            

        }
        });
    }

    void Start(){
        GetQuestData();
    }

    void Awake(){

    }

}