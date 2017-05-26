using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> floor;
    public int curFloor = 0;

    private static GameManager instance;
    public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public bool showGrid = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {

        if (showGrid)
        {
            Gizmos.color = Color.yellow;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Gizmos.DrawWireCube(new Vector3(transform.position.x + j, transform.position.y + i), new Vector3(1f, 1f));
                }
            }

        }

    }

}
