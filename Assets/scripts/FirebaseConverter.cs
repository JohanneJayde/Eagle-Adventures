using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;

public class FirebaseConverter<T> where T : new(){

        public T DeserializeObject(DataSnapshot row){

            T data = new T();

            foreach(var props in data.GetType().GetProperties()){
                if(props.Name == "QuestID"){
                    props.SetValue(data, row.Key, null);
                }
                
                else{
                    int num;
                    if(int.TryParse(Convert.ToString(row.Child(props.Name).Value), out num) && props.Name != "TimeCompletion"){
                        props.SetValue(data, Convert.ToInt32(num), null);
                    }
                    else{
                       props.SetValue(data, row.Child(props.Name).Value, null);
                    }
                }
            }

            return data;
        }

        public List<T> Deserialize(DataSnapshot data){

            List<T> serializedList = new List<T>();

            foreach(DataSnapshot obj in data.Children){
                 serializedList.Add(DeserializeObject(obj));
            }

            return serializedList;

        }

}

