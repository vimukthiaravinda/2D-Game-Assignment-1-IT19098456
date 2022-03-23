using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoots : MonoBehaviour
{
    public float shootspeed , ShootTimer;
    private bool isShooting;
    public Transform shootpoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;
        GameObject newbullet = Instantiate(bullet, shootpoint.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootspeed * direction() * Time.fixedDeltaTime, 0f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);
        yield return new WaitForSeconds(ShootTimer);
        isShooting = false;
    }
}
