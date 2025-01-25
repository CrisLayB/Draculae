using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    protected Coin _heldObject;
    [SerializeField] protected GameObject _anchor;

    // Propiedad que maneja el objeto genérico T
    public virtual Coin HeldObject
    {
        get
        {
            return _heldObject;
        }
        set
        {
            _heldObject = value;

            if (value != null)
            {
                value.gameObject.transform.parent = _anchor.transform;
                value.gameObject.transform.localPosition = Vector3.zero;
                value.gameObject.transform.rotation = Quaternion.identity;

                Rigidbody rg = value.gameObject.GetComponent<Rigidbody>();
                if(rg) rg.useGravity = false;                
            }
        }
    }

    private void Start()
    {
        _heldObject = _anchor.GetComponentInChildren<Coin>();
    }

    public virtual void RemoveHeldObject()
    {
        if (_heldObject != null)
        {
            Rigidbody rg = _heldObject.gameObject.GetComponent<Rigidbody>();
            if(rg) rg.useGravity = true;

            _heldObject.transform.parent = null;
        }
        
        _heldObject = null;
    }


    // Verificar si hay un objeto actual
    public virtual bool HasHeldObject()
    {
        return _heldObject != null;
    }
}
