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
            return JsonUtility.FromJson<Vector3>(file);
        }
        catch (Exception e)
        {
            return new Vector3(-20,2,15);
        }
    }

    public static void SaveLastPosition(Vector3 position)
    {
        var json= JsonUtility.ToJson(position);
        File.WriteAllText(Application.streamingAssetsPath + "/Save.json", json);
    }
}
