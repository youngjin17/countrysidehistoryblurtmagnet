using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Gravity_Switcher : MonoBehaviour {

    public float cooldown = 5f;
    private bool coolingDown;
    private Image abilityIcon;


	// Use this for initialization
	void Start () {
        abilityIcon = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SwitchGravity") && !coolingDown)
        {
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

    void SwitchGravity()
    {
        Physics2D.gravity *= -1;

    }
}
