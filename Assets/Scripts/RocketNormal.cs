using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNormal : MonoBehaviour {

    public Transform explosionPrefab;
    private Collider2D collisions;

    private void Start()
    {
        collisions = GetComponent<Collider2D>();
        Debug.Log(collisions.isTrigger);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
       
    }
}
