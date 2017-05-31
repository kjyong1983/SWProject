using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public static class SaveLoad {
    public static List<DataManager> savedGames = new List<DataManager>();
    public static List<string> savedString = new List<string>();
    public static int saveCount = 0;

    public static void Save()
    {
        PlayerPrefs.SetInt("SaveCount", saveCount++);
        if (DataManager.Instance == null)
        {
            Debug.Log("Null at Datamanager");
            var dataManager = DataManager.Instance;
        }

        DataManager.Instance.Save();

        var saveData = JsonUtility.ToJson(DataManager.Instance);
        savedString.Add(saveData);

        PlayerPrefs.Save();
        saveCount++;
        //PlayerPrefs.SetString();
    }

    //public static void Save()
    //{
    //    savedGames.Add(PlayerState.current);
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath + "/savedGames");
    //    file.Close();

    //}

    public static void Load()
    {
        if (saveCount == 0)
        {
            Debug.Log("no data");
            return;
        }
        //playerprefs and playerloc destroys when go to title screen. use dontdestroy or make plyaerspawner,
        //playerspawner has csvparser to player.
        if (PlayerLocation.playerLoc == null)
        {
            Debug.Log("no playerLoc");
           
        }

        DataManager.Instance.Load();

        //PlayerLocation.playerLoc.floorNum = PlayerPrefs.GetInt("floorNum");
        //PlayerLocation.playerLoc.floorX = PlayerPrefs.GetInt("floorX");
        //PlayerLocation.playerLoc.floorY = PlayerPrefs.GetInt("floorY");
        //PlayerLocation.playerLoc.roomNum = PlayerPrefs.GetInt("roomNum");
        //PlayerLocation.playerLoc.roomX = PlayerPrefs.GetInt("roomX");
        //PlayerLocation.playerLoc.roomY = PlayerPrefs.GetInt("roomY");

    }

    internal static void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        saveCount = 0;
    }

    //public static void Load()
    //{
    //    if (File.Exists(Application.persistentDataPath + "/savedGames"))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file = File.Open(Application.persistentDataPath + "/savedGames", FileMode.Open);
    //        SaveLoad.savedGames = (List<PlayerState>)bf.Deserialize(file);
    //        file.Close();
    //    }
    //}


}
