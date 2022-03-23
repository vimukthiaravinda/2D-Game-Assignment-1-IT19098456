using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add colider to health pack
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class Health_pack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Object;
    public Healthbar Healthbar;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            Object.SetActive(false);
            Healthbar.fillLife(100);
        }
    }
}
