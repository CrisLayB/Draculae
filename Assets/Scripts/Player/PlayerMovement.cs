using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private InputConfig playerInput;
    private CharacterController _characterController;
    private PlayerAnimations _animations;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {        
        float horizontal = Input.GetAxis(playerInput.horizontalAxis);
        float vertical = Input.GetAxis(playerInput.verticalAxis);
        
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;

        if(movement.magnitude != 0) transform.forward = movement;
             
        _characterController.SimpleMove(movement);

         float movementMagnitude = new Vector2(horizontal, vertical).magnitude;    
        _animations.WalkingAnimation(movementMagnitude);
    }
}
