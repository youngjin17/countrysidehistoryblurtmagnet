using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Rigidbody2D missile;
    public float chargeSpeed = 20f;
    public float missileBaseSpeed = 3f;

    private Transform shotSpawn;
    private float chargeTime;
    private float startTime;
    private SpriteRenderer spriteRenderer;
    private bool facingRight;
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
        facingRight = transform.parent.localScale.x > 0;
        if (Input.GetButtonDown("NormalMissile"))
        {
            startTime = Time.time;
            Debug.Log("charging");
        }
        else if (Input.GetButtonUp("NormalMissile"))
        {
            Shoot(Time.time - startTime);
            startTime += Time.time;
        }
        
    }

    void Shoot(float chargeTime)
    {
        float projectileSpeed = chargeTime * chargeSpeed + missileBaseSpeed;
        Debug.Log("shoot!");
        Quaternion rotation = new Quaternion(0, (facingRight ? 0 : 180), 0, 1);
        Rigidbody2D clone = Instantiate(missile, shotSpawn.position, rotation) as Rigidbody2D;
        clone.velocity = (facingRight ? transform.right : (transform.right * -1)) * projectileSpeed;

    }

}
