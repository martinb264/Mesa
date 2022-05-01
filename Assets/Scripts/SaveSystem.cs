using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //https://www.youtube.com/watch?v=XOjd_qU2Ido
   public static void savePlayer(Transform player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/playerData.data";
        string path = "C:\\Users\\marti\\Desktop\\Game Assets\\playerData.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayer()
    {
        string path = "C:\\Users\\marti\\Desktop\\Game Assets\\playerData.data";
        //string path = Application.persistentDataPath + "/playerData.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save File Not Found");
            return null;
        }
    }
}
