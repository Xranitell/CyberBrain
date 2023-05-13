using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadSystem
{
    public static Vector3 LoadLastPosition()
    {
        var file = File.ReadAllText(Application.streamingAssetsPath + "/Save.json");
        try
        {
            var a = JsonUtility.FromJson<Vector3>(file);
            return a;
        }
        catch 
        {
            return new Vector3(-20,2,-5);
        }
    }

    public static void SaveLastPosition(Vector3 position)
    {
        var json= JsonUtility.ToJson(position);
        File.WriteAllText(Application.streamingAssetsPath + "/Save.json", json);
    }
}
