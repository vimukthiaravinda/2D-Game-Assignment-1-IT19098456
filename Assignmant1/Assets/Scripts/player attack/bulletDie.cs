using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDie : MonoBehaviour
{
    public float dieTime;
    public GameObject DiePE;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObjectCollision = collision.gameObject;

        if(gameObjectCollision.name != "Player")
        {
            Die();
        }
    }

    void Die()
    {
         if (DiePE != null)
        {
            Instantiate(DiePE, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
}
