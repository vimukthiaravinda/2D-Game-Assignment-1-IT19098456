using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AIpetrol : MonoBehaviour
{
    public float walkspeed, range,TimeBWshots, ShootSpeed;
    private float disToplaye;
    [HideInInspector]
    public bool mustpetrol;
    private bool mustTurn, canshoot;
    public Rigidbody2D rb;
    public Transform groundcheckpos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player;
    public Transform pos;

    public GameObject bullet, Aienemy;
    void Start()
    {
        mustpetrol = true;
        canshoot = true;
    }

    void Update()
    {
        if(mustpetrol == true)
        {
            Patrol();
        }

        disToplaye = Vector2.Distance(transform.position, player.position);

        if(disToplaye <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }


            mustpetrol = false;
            rb.velocity = Vector2.zero;
            if (canshoot){
                StartCoroutine(Shoot());
            }
            
        }
        else
        {
            mustpetrol = true;
        }

    }
     private void FixedUpdate()
     {
         if (mustpetrol == true)
         {
             mustTurn = !Physics2D.OverlapCircle(groundcheckpos.position, 0.1f, groundLayer);
         }
     }
    void Patrol()
    {
        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, rb.velocity.y);

        if (mustTurn == true || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
  

    }

    void Flip()
    {
        mustpetrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        mustTurn = false;
        mustpetrol = true;
    }

    IEnumerator Shoot()
    {
        canshoot = false;
        yield return new WaitForSeconds(TimeBWshots);
        GameObject newBullet = Instantiate(bullet,pos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(ShootSpeed * walkspeed * Time.fixedDeltaTime, 0f);
        canshoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerbullet")
        {
            Aienemy.SetActive(false);
        }else{
            return ;
        }
    }
}
