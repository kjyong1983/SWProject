using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {
    public static List<PlayerState> savedGames = new List<PlayerState>();

    public static void Save()
    {
        savedGames.Add(PlayerState.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames");
        file.Close();

    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames", FileMode.Open);
            SaveLoad.savedGames = (List<PlayerState>)bf.Deserialize(file);
            file.Close();
        }
    }


}
