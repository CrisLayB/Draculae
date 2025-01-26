using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinOnTheGround : MonoBehaviour
{
    [SerializeField] private AudioSource _coinSound;

    private void Start() 
    {
        _coinSound = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<Coin>())
        {
            _coinSound?.Play();
        }
    }
}
