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
public class FirebaseReader {

   DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    public string Branch {get;}

    public DataSnapshot Data {get;}


    public T returnData<T>(){
        return Data;
    }

    public void setData(){

    reference
        .Child(Branch)
        .GetValueAsync().ContinueWithOnMainThread(task => {
        if (task.IsFaulted) {
            Debug.Log("failed");

        }
        else if (task.IsCompleted) {
            DataSnapshot snapshot = task.Result;

        }
        });
    }

}



