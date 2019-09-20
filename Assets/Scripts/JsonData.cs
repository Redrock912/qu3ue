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


        //FileStream stream = new FileStream(path, FileMode.Create);

        //BuffData newData = new BuffData();

    }

    public static BuffDataList LoadBuffDataFromJson()
    {

        BinaryFormatter foramtter = new BinaryFormatter();


        

        // 현재는 클라이언트
        string path = Path.Combine(Application.dataPath, "buffData.json");

        string jsonData = File.ReadAllText(path);
        return JsonUtility.FromJson<BuffDataList>(jsonData);
        
    }
}
