using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

/*
* Firebase is a testing script used to test out Firebase functionality within our app. This will be deleted when the properly
* scripts for manipulating has been cretaed.
*/
public class FirebaseTester {

   DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    public void TestConnection(){

    reference
        .Child("Quests")
        .GetValueAsync().ContinueWithOnMainThread(task => {
        if (task.IsFaulted) {
            Debug.Log("failed");

        }
        else if (task.IsCompleted) {
            DataSnapshot snapshot = task.Result;

            foreach(DataSnapshot quest in snapshot.Children){
                Debug.Log(quest.Child("Title").Value);
            }
        }
        });
    }

}



