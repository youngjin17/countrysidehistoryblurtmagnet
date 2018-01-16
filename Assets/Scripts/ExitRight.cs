using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int direction = Object.FindObjectOfType<RightOfWay>().getDirection();
        if (collision.tag == "Player" && direction == 1)
        {
            SceneManager.LoadScene("Simple");
        }
    }
}
