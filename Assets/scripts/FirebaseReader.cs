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
public class FirebaseReader {

   DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    public string Branch {get; set;}

    public DataSnapshot Data {get; set;}

    public DataSnapshot returnBranchData(){
        return Data;
    }

    // public Task<DataSnapshot> retriveBranchData(){

    //     DataSnapshot branchData = null; 

    //     reference
    //     .Child(Branch)
    //     .GetValueAsync().ContinueWithOnMainThread(task => {
    //     if (task.IsFaulted) {
    //         Debug.Log("failed");

    //     }
    //     else if (task.IsCompleted) {
    //         branchData = task.Result;

    //     }
    //     }
    //     return branchData;

    // }

    // public async void setData(){
    //     Data = await retriveBranchData();
    // }

    public void printData(){
        foreach(DataSnapshot quest in Data.Children){
                Debug.Log(quest.Key);

                foreach(DataSnapshot prop in quest.Children){
                    Debug.Log(prop.Key + ": " + prop.Value);
                }

            }
    }

}



