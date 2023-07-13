using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;

/*
 * GoogleSheet Importer is used to get Quest data our Google Sheet
 */
public class GoogleSheetsImporter
{
    public SheetsService service {get; set;}
    static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static readonly string ApplicationName = "Eagle Adventures";
    static readonly string sheetsID = "1JGQ2pWLYkvCAEFNawKA_PuXusBr2_FTwPLH44mz7jcw";
    static readonly string sheetName = "QuestSheet";

   public GoogleCredential credentialsInfo;

    public void SetService(){

        using (var streamReader = new FileStream(Application.streamingAssetsPath + "/eagle-adventures-15cf32510c1b.json", FileMode.Open, FileAccess.Read)){
            credentialsInfo = GoogleCredential.FromStream(streamReader)
            .CreateScoped(Scopes);
        }

        service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer(){
            HttpClientInitializer = credentialsInfo,
            ApplicationName = ApplicationName

        });
    }

    public void ReadSheet(){

        var range = $"{sheetName}!A1:J100";
        var request = service.Spreadsheets.Values
        .Get(sheetsID, range);

        var response = request.Execute();
        var values = response.Values;

        if(values != null && values.Count > 0)
        {
            foreach(var row in values){
                Debug.Log(row[1]);
            }
        }
        else{
            Debug.Log("NO DATA FOUND");
        }
    }
}
