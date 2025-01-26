using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Player" | enter.gameObject.tag == "Coin") 
        {
            GameObject.Find("BubbleAudio").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
