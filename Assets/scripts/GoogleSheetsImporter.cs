using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cathei.BakingSheet;
using Cathei.BakingSheet.Internal;
using Cathei.BakingSheet.Unity;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Runtime;

public class GoogleSheetsImporter : MonoBehaviour
{

    public class SheetContainer : SheetContainerBase{

        public SheetContainer(Microsoft.Extensions.Logging.ILogger logger) : base(UnityLogger.Default) {}
        public QuestSheet QuestSheet {get; set;}

    }

    public class QuestSheet : Sheet<QuestSheet.Row>
    {
        public class Row : SheetRow 
        {
            public string Address {get; set;}
        }
    }


    string sheetID = "1JGQ2pWLYkvCAEFNawKA_PuXusBr2_FTwPLH44mz7jcw";
    string sheetID2 = "1Faa3a2OZPeCnI7HKim9xn9rOcqQtzy2kXtCVtYkrcsw";
    string creds;


    // Start is called before the first frame update
    public async void LoadSheet(){

        SheetContainer container = new SheetContainer(UnityLogger.Default);
        creds = File.ReadAllText("Assets/data/eagle-adventures-15cf32510c1b.json");
        var googleConverter = new GoogleSheetConverter(sheetID, creds);
        
        Debug.Log("Awaiting...");
        await container.Bake(googleConverter);

        for(int i = 0; i < container.QuestSheet.Count; i++){
            Debug.Log($"Title: {container.QuestSheet[i].Address}");
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
