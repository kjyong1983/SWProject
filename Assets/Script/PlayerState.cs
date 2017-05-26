using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState : MonoBehaviour {

    public static PlayerState current;
    public PlayerState Current
    {
        get
        {
            if (current == null)
            {
                current = new PlayerState();
            }
            return current;
        }
    }

    public PlayerLocation location;
    public string str;
    public int floorNum, floorX, floorY, roomNum, roomX, roomY;

    void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        floorNum = location.floorNum;
        floorX = location.floorX;
        floorY = location.floorY;
        roomNum = location.roomNum;
        roomX = location.roomX;
        roomY = location.roomY;

    }
    void Initialize()
    {
        current = this;

        location = GetComponent<PlayerLocation>();
        //location 초기화
        
    }

}
