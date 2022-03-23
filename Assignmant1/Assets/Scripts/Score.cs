using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myscore;
    public int scorenum = 0;
    // Start is called before the first frame update
    void Start()
    {
        myscore.text = "Score : " + scorenum;  
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.tag == "coin")
        {
            scorenum++;
            myscore.text = "Score : " + scorenum;
        }
    }
}
