using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemy : MonoBehaviour
{

    public Transform explosionPrefab;
    private Collider2D collisions;
    public string[] whatNotToHit;


    private void OnTriggerEnter2D(Collider2D other)
    {
        bool toExplode = true;
        foreach (string str in whatNotToHit)
        {
            if (other.tag == str)
            {
                toExplode = false;
            }
        }
        if (toExplode)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
