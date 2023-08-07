using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveHandler
{


    void LoadPlayerData();

    void LoadProgressData();

    void SaveData();
    void LoadProgress();
    void DeleteData();



}
