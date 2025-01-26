using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int coin_counter;
        
    void OnTriggerEnter(Collider enter) 
    {
        if (enter.gameObject.tag == "Coin")
            coin_counter++;
    }

    void OnTriggerExit(Collider exit)
    {
        if (exit.gameObject.tag == "Coin")
            coin_counter--;
    }

    public int GetCoinCount() 
    {
        return coin_counter;
    }

    public int CounCounter
    {
        get { return coin_counter; }        
    }
}
