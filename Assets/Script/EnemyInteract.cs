using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour {

    GameObject interactCollider;
    EnemyController e;
    CircleCollider2D detector;
    public float radius = 3f;

	// Use this for initialization
	void Start () {

        e = GetComponent<EnemyController>();
        interactCollider = new GameObject("EnemyintactCol");
        interactCollider.transform.SetParent(e.transform);
        interactCollider.transform.position = e.transform.position;
        interactCollider.tag = "Ignored";
        detector = interactCollider.AddComponent<CircleCollider2D>().GetComponent<CircleCollider2D>();
        detector.isTrigger = true;
        detector.radius = radius;

        interactCollider.AddComponent<EnemyInteractTrigger>();
    }

    // Update is called once per frame
    void Update () {
		
	}


}
