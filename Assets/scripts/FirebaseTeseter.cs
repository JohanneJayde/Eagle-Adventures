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
public class FirebaseTester : MonoBehaviour {



    public void TestConnection(){

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
                converter.convertData(quest);

                // Debug.Log(quest.Key);

                // foreach(DataSnapshot prop in quest.Children){
                //     Debug.Log(prop.Key + ": " + prop.Value);
                // }

            }
        }
        });
    }

    void Start(){
        TestConnection();
    }

    void Awake(){

    }

}