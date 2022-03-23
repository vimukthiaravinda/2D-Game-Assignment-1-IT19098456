using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject Camera;
    public float ParallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = (Camera.transform.position.x * ParallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
