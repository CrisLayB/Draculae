using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    protected Coin _heldCoin;
    [SerializeField] protected GameObject _anchor;

    // Propiedad que maneja el objeto genérico T
    public virtual Coin HeldObject
    {
        get
        {
            return _heldCoin;
        }
        set
        {
            _heldCoin = value;

            if (value != null)
            {
                value.gameObject.transform.parent = _anchor.transform;
                value.gameObject.transform.localPosition = Vector3.zero;
                value.gameObject.transform.rotation = Quaternion.identity;
                _heldCoin.ResetVelocity();
            }
        }
    }

    private void Start()
    {
        _heldCoin = _anchor.GetComponentInChildren<Coin>();
    }

    public virtual void RemoveHeldObject()
    {
        if (_heldCoin != null)
        {
            _heldCoin.ThrowCoin(transform.forward);
            _heldCoin.transform.parent = null;
        }
        
        _heldCoin = null;
    }


    // Verificar si hay un objeto actual
    public virtual bool HasHeldObject()
    {
        return _heldCoin != null;
    }
}
