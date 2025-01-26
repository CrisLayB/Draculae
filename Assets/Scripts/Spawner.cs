using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin_prefab;
    private Vector3[] _coin_positions;
    private ArrayList _coin_list = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        _coin_positions = new Vector3[transform.hierarchyCount];

        for (int i = 0; i < transform.hierarchyCount - 1; i++)
        {
            _coin_positions[i] = transform.GetChild(i).position;
        }

        foreach (Transform child in transform) {
            GameObject coin = Instantiate(_coin_prefab, child.position, child.rotation);
            _coin_list.Add(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
