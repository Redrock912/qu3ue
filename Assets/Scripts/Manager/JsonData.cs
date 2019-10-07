using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class JsonData
{
    
    public static void SaveBuffDataToJson(BuffDataList buffList)
    {

        BinaryFormatter foramtter = new BinaryFormatter();
        

        string jsonData = JsonUtility.ToJson(buffList,true);
        
        // 현재는 클라이언트
        string path = Path.Combine(Application.dataPath ,"buffData.json");
        File.WriteAllText(path, jsonData);

    }
    public static BuffDataList LoadBuffDataFromJson(string jsonPath)
    {

        BinaryFormatter foramtter = new BinaryFormatter();

        // 현재는 클라이언트
        string path = Path.Combine(Application.dataPath, jsonPath + ".json");

        string jsonData = File.ReadAllText(path);
        return JsonUtility.FromJson<BuffDataList>(jsonData);
        
    }

    public static void SaveRunnerDataToJson(RunnerData runnerData)
    {

     


        string jsonData = JsonUtility.ToJson(runnerData, true);

        // 현재는 클라이언트
        string path = Path.Combine(Application.dataPath, "RunnerData.json");
        File.WriteAllText(path, jsonData);

    }


    public static RunnerData LoadRunnerDataFromJson()
    {
        // 현재는 클라이언트
        string path = Path.Combine(Application.dataPath, "RunnerData.json");

        string jsonData = File.ReadAllText(path);
        return JsonUtility.FromJson<RunnerData>(jsonData);
    }

    
}
