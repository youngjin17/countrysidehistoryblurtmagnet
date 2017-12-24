using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNormal : PhysicsObject {

    public Transform explosionPrefab;

    protected override void ComputeVelocity()
    {
        if (grounded)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
