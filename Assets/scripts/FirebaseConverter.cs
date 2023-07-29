using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Firebase.Database;
public class FirebaseConverter<T> where T : new(){

    IEnumerable<T> SerializedData;

        public T convertData(DataSnapshot row){

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

}

