using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {
    public static List<PlayerState> savedGames = new List<PlayerState>();
    public static int saveCount = 0;

    public static void Save()
    {
        PlayerPrefs.SetInt("SaveCount", saveCount++);
        if (PlayerState.current == null)
        {
            Debug.Log("Null at PlayeState");
            return;
        }
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("floorNum", PlayerState.current.floorNum);
        PlayerPrefs.SetInt("floorX", PlayerState.current.floorX);
        PlayerPrefs.SetInt("floorY", PlayerState.current.floorY);
        PlayerPrefs.SetInt("roomNum", PlayerState.current.roomNum);
        PlayerPrefs.SetInt("roomX", PlayerState.current.roomX);
        PlayerPrefs.SetInt("roomY", PlayerState.current.roomY);
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
            Debug.Log("no data");
            return;
        }
        PlayerLocation.playerLoc.floorNum = PlayerPrefs.GetInt("floorNum");
        PlayerLocation.playerLoc.floorX = PlayerPrefs.GetInt("floorX");
        PlayerLocation.playerLoc.floorY = PlayerPrefs.GetInt("floorY");
        PlayerLocation.playerLoc.roomNum = PlayerPrefs.GetInt("roomNum");
        PlayerLocation.playerLoc.roomX = PlayerPrefs.GetInt("roomX");
        PlayerLocation.playerLoc.roomY = PlayerPrefs.GetInt("roomY");

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
