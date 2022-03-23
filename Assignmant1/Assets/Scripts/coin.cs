using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class coin : MonoBehaviour
{
    public GameObject Object;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            Object.SetActive(false);
        }
    }
}
