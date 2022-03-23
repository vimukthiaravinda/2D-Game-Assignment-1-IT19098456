using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //health bar control
    public Image fill_health_bar;
    public GameObject player;
    //health value 
    public float health;
    public bool state = false;

    public void LossLife(float value) 
    {
        // Nothing happens if out of health
        if (health <= 0)
        {
            return;
        }
        //health value reducer 
        health -= value;
        // refresh helthbar ui 
        fill_health_bar.fillAmount = health / 100;

        // check health state 
        if(health <= 0)
        {
            player.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void fillLife(float addhealth)
    {
        health += addhealth;
        fill_health_bar.fillAmount = health / 100;

    }

    private void Update()
    {
        if (state == true)
        {
            LossLife(20f);
            state = false;
        }
    }

    public void StateFind()
    {
        state = true;
    }

}
