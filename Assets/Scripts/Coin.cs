using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private float throwedCoinVelocity;
    private Rigidbody _rigidbody;

    private void Start() 
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        if(_rigidbody.velocity != Vector3.zero)
        {            
            _rigidbody.velocity *= 0.99f;
            _rigidbody.angularVelocity *= 0.99f;
        }
    }

    public void Highlight()
    {
        mesh.material = highlightMaterial;
    }

    public void OriginalMaterial()
    {
        mesh.material = originalMaterial;
    }

    public void ThrowCoin(Vector3 positionForward)
    {            
        if(_rigidbody)
        {
            _rigidbody.velocity = positionForward * throwedCoinVelocity;
            _rigidbody.useGravity = true;
        }
    }

    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.rotation = Quaternion.identity;
        _rigidbody.useGravity = false;
    }
}
