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
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            GameObject.Find("Fire Spawner").GetComponent<FireSpawner>().SpawnFireball(velocity);
            Destroy(gameObject);
        }
    }
}
