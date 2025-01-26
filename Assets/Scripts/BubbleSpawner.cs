using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bubble_prefab;
    [SerializeField] private float _bubbleRange = -3.5f;

    public void StartingSpawnBubbles()
    {
        InvokeRepeating("SpawnNewBubbles", 1.0f, 3.0f);
    }

    public void StopSpawnBubbles()
    {
        CancelInvoke("SpawnNewBubbles");
    }

    private void SpawnNewBubbles()
    {
        float x = Random.Range(-1.5f, 1.5f);
        GameObject bubble = Instantiate(_bubble_prefab, transform.position, Quaternion.identity);
        Rigidbody rb_bubble = bubble.GetComponent<Rigidbody>();

        rb_bubble.AddForce(new Vector3(x, 0, _bubbleRange), ForceMode.VelocityChange);
    }
}
