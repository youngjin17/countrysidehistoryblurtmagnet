using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNormal : PhysicsObject {

    public Transform explosionPrefab;
    private Collider2D collisions;

    private void Start()
    {
        collisions = GetComponent<Collider2D>();
        Debug.Log(collisions.isTrigger);
        Debug.Log(collisions.offset);
    }

    protected override void ComputeVelocity()
    {
        if (hitWall || grounded)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
