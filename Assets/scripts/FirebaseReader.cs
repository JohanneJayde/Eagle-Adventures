using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Threading.Tasks;
/*
* Firebase is a testing script used to test out Firebase functionality within our app. This will be deleted when the properly
* scripts for manipulating has been cretaed.
*/
public class FirebaseReader : MonoBehaviour {



    public void GetQuestData(){

        DataSnapshot curData = null;

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
            
            foreach(DataSnapshot quest in snapshot.Children){
                Quest quests = converter.convertData(quest);
                Debug.Log(quests);


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