using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Rigidbody2D missileUp;
    public Rigidbody2D missileDown;
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
        if (Input.GetButtonDown("MissileUp"))
        {
            startTime = Time.time;
            Debug.Log("charging");
        }
        else if (Input.GetButtonUp("MissileDown"))
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
        Rigidbody2D clone = Instantiate(missileDown, shotSpawn.position, rotation) as Rigidbody2D;
        clone.velocity = (facingRight ? transform.right : (transform.right * -1)) * projectileSpeed;

    }

}
