using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _fire_prefab;


    public void SpawnFireball(Vector3 direction)
    {
        GameObject fireball = Instantiate(_fire_prefab, transform.position, Quaternion.identity);
        Rigidbody rb_fireball = fireball.GetComponent<Rigidbody>();

        rb_fireball.AddForce(direction * 3, ForceMode.VelocityChange);
    }
}
