using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Firebase.Database;
public class FirebaseConverter<T>{

    IEnumerable<T> SerializedData;

        public void convertData(DataSnapshot row){

            foreach(var props in typeof(T).GetProperties()){
                if(props.Name == "QuestID"){
                    Debug.Log(props.Name);
                    Debug.Log(row.Key);
                }
                
                else{Debug.Log(props.Name);
                Debug.Log(row.Child(props.Name).Value);
                }
            }


        }

}

