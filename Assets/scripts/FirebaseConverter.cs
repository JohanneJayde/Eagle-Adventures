using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;

public class FirebaseConverter{

        /// <summary>
        /// Given a type, convert the DataSnaphot to it
        /// </summary>
        /// <param name="row">row represents a snapshot</param>
        /// <typeparam name="T">Type you want the param to be deserialized to</typeparam>
        /// <returns>DataSnapshot as type T</returns>
        public static T DeserializeObject<T>(DataSnapshot row) where T : class, new(){

            T data = new T();

            foreach(var props in data.GetType().GetProperties()){
                if(props.Name == "QuestID"){
                    props.SetValue(data, row.Key, null);
                }
                
                else{
                    int num;
                    if(int.TryParse(Convert.ToString(row.Child(props.Name).Value), out num) && props.Name != "TimeCompletion"){
                        props.SetValue(data, num, null);
                    }
                    else{
                       props.SetValue(data, row.Child(props.Name).Value, null);
                    }
                }
            }

            return data;
        }

        public static List<T> Deserialize<T>(DataSnapshot data) where T : class, new(){

            List<T> serializedList = new List<T>();

            foreach(DataSnapshot obj in data.Children){
                 serializedList.Add(DeserializeObject<T>(obj));
            }

            return serializedList;

        }

}

