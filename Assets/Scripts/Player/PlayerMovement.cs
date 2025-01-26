using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool _startToWalk = false;
    [SerializeField] private InputConfig playerInput;
    private CharacterController _characterController;
    private PlayerAnimations _animations;
    private bool _inmunity = false;

    public void StartToWalk() => _startToWalk = true;

    public void StopToWalk() 
    {
        _startToWalk = false;
        _animations.WalkingAnimation(0);
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {        
        if(!_startToWalk) return;
        
        float horizontal = Input.GetAxis(playerInput.horizontalAxis);
        float vertical = Input.GetAxis(playerInput.verticalAxis);
        
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;

        if(movement.magnitude != 0) transform.forward = movement;
             
        _characterController.SimpleMove(movement);

         float movementMagnitude = new Vector2(horizontal, vertical).magnitude;    
        _animations.WalkingAnimation(movementMagnitude);
    }

    // TODO: Create a OnTriggerEvent of OnCollisionEnter and call Burned and StopToWalk in a Coroutine
    void OnTriggerEnter(Collider enter)
    {
        IEnumerator coroutine = Burned();
        if (enter.gameObject.tag == "Fireball" & !_inmunity)
        {
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator Burned()
    {
        _inmunity = true;
        GetComponent<PlayerAnimations>().Burned();
        StopToWalk();
        yield return new WaitForSeconds(3);
        StartToWalk();
        // Call inmunity animation
        yield return new WaitForSeconds(1.5f);
        _inmunity = false;
    }

}
