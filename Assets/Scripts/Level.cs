using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    private Collider2D collisions;
	// Use this for initialization
	void Start () {
        collisions = GetComponent<Collider2D>();
        Debug.Log(collisions.isTrigger);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
