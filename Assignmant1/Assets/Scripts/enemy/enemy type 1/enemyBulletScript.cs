using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBulletScript : MonoBehaviour
{
    public float dieTime;
    //public Healthbar healthbar;

    void Start()
    {
        StartCoroutine(CountDownTime());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    void Die()
    {
        Destroy(gameObject); 
    }
}
