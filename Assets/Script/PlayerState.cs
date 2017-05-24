using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState {

    public static PlayerState current;
    public Location location;
    public string str;
    public int floorNum, floorX, floorY, roomNum, roomX, roomY;
    
    PlayerState()
    {
        this.str = "asdf";
        floorNum = location.floorNum;
        floorX = location.floorX;
        floorY = location.floorY;
        
    }

}
