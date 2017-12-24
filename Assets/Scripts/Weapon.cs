using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public LayerMask NotToHit;
    public Rigidbody2D missile;
    public float chargeSpeed = 20f;
    public float missileBaseSpeed = 3f;

    private Transform shotSpawn;
    private float chargeTime;
    private float startTime;
	// Use this for initialization

	void Start () {
        startTime = Time.time;
        shotSpawn = transform.Find("shotSpawn");

        if (shotSpawn == null)
        {
            Debug.LogError("No firepoint?");
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
            Debug.Log("charging");
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Shoot(Time.time - startTime);
            startTime += Time.time;
        }
        
    }

    void Shoot(float chargeTime)
    {
        float projectileSpeed = chargeTime * chargeSpeed + missileBaseSpeed;
        Debug.Log("shoot!");

        Rigidbody2D clone = Instantiate(missile, shotSpawn.position, shotSpawn.rotation) as Rigidbody2D;
        clone.velocity = transform.right * projectileSpeed;

    }

}
