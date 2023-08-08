using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveHandler
{

    //Command Pattern?

    //class PlayerDataSaveHandler : ISaveHandler
    //class PlayerProgressDataSaveHandler : ISaveHandler
    //Principle Data Saver


    //PlayerSaver : Saveable
    //PlayerData
    //PlayerProgress : Saveable

    //PlayerManger holds the and manipulates the data when it maybe should
    //just hold the data or swap it to PlayerData holds the data and then we edit that
    //Meaniing PlayerData data holds the data and then

    //Saveable
        //Path: String
        //Data: IEnumerable

        //Methods
        //Get Data

    //SaveData(Saveablbe save)

    void LoadData();
    void SaveData();
    void CreateData();
    void DeleteData();



}
