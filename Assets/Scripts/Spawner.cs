using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin_prefab;
    [SerializeField] private float _z_upper, _z_lower, _x_upper, _x_lower;

    // Start is called before the first frame update
    public void StartingSpawnCoins()
    {
        InvokeRepeating("SpawnNewCoins", 1.0f, 3.0f);
    }

    public void StopSpawnCoins()
    {
        CancelInvoke();
    }

    private void SpawnNewCoins() {

        float x = UnityEngine.Random.Range(_x_lower, _x_upper);
        float z = UnityEngine.Random.Range(_z_lower, _z_upper);
        Instantiate(_coin_prefab, new Vector3(x, 3.0f, z), Quaternion.identity);
    }    
}
