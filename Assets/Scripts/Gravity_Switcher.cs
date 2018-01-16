using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gravity_Switcher : MonoBehaviour
{

    public float cooldown = 5f;
    private bool coolingDown;
    private Image abilityIcon;
    private GameObject player;
    private GameObject enemy;

    // Use this for initialization
    void Start()
    {
        abilityIcon = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SwitchGravity") && !coolingDown)
        {
            UpdateAlive();
            coolingDown = true;
            SwitchGravity();
            abilityIcon.fillAmount = 0;
        }
        else if (abilityIcon.fillAmount == 1f)
        {
            coolingDown = false;
        }
        else
        {
            abilityIcon.fillAmount += 1.0f / cooldown * Time.deltaTime;
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
                Debug.Log("succes");
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

    void SwitchGravity()
    {
        GameObject.FindObjectOfType<PlatformerCharacter2D>().FlipVertical();
    }
}
