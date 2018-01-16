using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightOfWay : MonoBehaviour {

    private int direction;
    private GameObject player;
    private GameObject enemy;
    private Image icon;

	// Use this for initialization
	void Start () {
        direction = 0;
        icon = GetComponent<Image>();
        icon.fillAmount = 0;
	}
	
	// Update is called once per frame

    public void DirectionChooser()
    {
        UpdateAlive();
        Debug.Log("success");
        if (player == null && enemy != null)
        {
            direction = -1;
        }
        else if (player != null && enemy == null)
            direction = 1;
        else
            direction = 0;
        WhichDirection(direction);
    }


    public int getDirection()
    {
        return direction;
    }

    private void WhichDirection(int x)
    {
        if (direction == 1)
        {
            Debug.Log("double scuces");
            icon.fillAmount = .5f;
            icon.fillMethod = Image.FillMethod.Vertical;
            icon.fillOrigin = 0;
        }
        else if (direction == -1)
        {
            Debug.Log("bruh");
            icon.fillAmount = .5f;
            icon.fillMethod = Image.FillMethod.Vertical;
            icon.fillOrigin = (int)Image.OriginVertical.Top;
        }
        else
        {
            Debug.Log("failed");
            Debug.Log(enemy);
            icon.fillAmount = 0;
        }
    }

    private void UpdateAlive()
    {
        GameObject[] array = Object.FindObjectsOfType<GameObject>();
        bool foundPlayer = false;
        bool foundEnemy = false;
        foreach (GameObject obj in array)
        {
            if (obj.tag == "Player")
            {
                player = obj;
                foundPlayer = true;
            }
            else if (obj.tag == "Enemy")
            {
                enemy = obj;
                foundEnemy = true;
            }
        }
        if (!foundPlayer)
            player = null;
        if (!foundEnemy)
            enemy = null;
    }
}
