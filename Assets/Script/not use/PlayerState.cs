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

    void Awake()
    {
        Initialize();
    }
    private void Update()
    {

    }
    void Initialize()
    {
        current = this;

        location = GetComponent<PlayerLocation>();
        //location 초기화
        
    }

}
