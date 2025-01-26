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
            GameObject fire_spawner = GameObject.Find("Fire Spawner");
            if (fire_spawner != null) 
            {
                Vector3 velocity = GetComponent<Rigidbody>().velocity;
                fire_spawner.GetComponent<FireSpawner>().SpawnFireball(velocity);
            }
            Destroy(gameObject);
        }
    }
}
