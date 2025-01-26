using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float highDistance = 0.7f;
    [SerializeField] private float distance = 1.5f;
    [SerializeField] private InputConfig playerInput;

    private Coin _coinSelected;
    private Holder _holder;
    private Vector3 _positionFixed;
    private PlayerAnimations _animations;
    
    private void Start() 
    {
        _holder = GetComponent<Holder>();
        _animations = GetComponent<PlayerAnimations>();
    }
    
    private void Update() 
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if(Input.GetKeyDown(playerInput.action.keyboardKey) || Input.GetKeyDown(playerInput.action.controllerButton))
        {
            ActionToDoWithTheCoin();
        }
    }

    private void ActionToDoWithTheCoin()
    {
        if(_holder.HasHeldObject()) // Si tiene la moneda
        {
            _holder.RemoveHeldObject();
            _animations.ThrowCoin();
            return;
        }

        if(_coinSelected == null) return;

        if(!_holder.HasHeldObject()) // Si no tiene la moneda
        {
            Coin coinToSet = _coinSelected;
            _coinSelected?.OriginalMaterial();
            _coinSelected = null;
            _holder.HeldObject = coinToSet;
            _animations.GetCoin();
        }
    }
    
    private void FixedUpdate() 
    {
        _positionFixed = new Vector3(transform.position.x, transform.position.y - highDistance, transform.position.z);        
        DetectCoin();
    }

    private void DetectCoin()
    {
        if(_holder.HasHeldObject()) return;
        
        if(Physics.Raycast(_positionFixed, transform.TransformDirection (Vector3.forward), out RaycastHit hitInfo, distance))
        {
            CoinActionToDo(hitInfo);
        }
        else
        {
            _coinSelected?.OriginalMaterial();
            _coinSelected = null;
            Debug.DrawRay(_positionFixed, transform.TransformDirection(Vector3.forward) * distance, Color.green);
        }
    }

    private void CoinActionToDo(RaycastHit hitInfo)
    {
        Coin coin = hitInfo.collider.gameObject.GetComponent<Coin>();

        if(coin)
        {
            Debug.DrawRay(_positionFixed, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            _coinSelected?.OriginalMaterial();
            _coinSelected = coin;
            _coinSelected?.Highlight();
        }
        else
        {
            _coinSelected?.OriginalMaterial();
            _coinSelected = null;
        }
    }
}
