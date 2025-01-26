using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool _startToWalk = false;
    [SerializeField] private InputConfig playerInput;
    [SerializeField] private Color burnedColor = Color.black;
    private SkinnedMeshRenderer[] _meshes;
    private Material[] _originalMaterialMeshes;
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
        _meshes = GetComponentsInChildren<SkinnedMeshRenderer>();

        if(_meshes == null) return;

        _originalMaterialMeshes = new Material[_meshes.Length];
        for (int i = 0; i < _meshes.Length; i++)
        {
            _originalMaterialMeshes[i] = _meshes[i].material;
        }
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
        // TODO: Set burnedColor color to the _meshes
        foreach (SkinnedMeshRenderer mesh in _meshes)
        {
            Material burnedMaterial = new Material(mesh.material)
            {
                color = burnedColor
            };
            mesh.material = burnedMaterial;
        }
        
        _inmunity = true;
        _animations.Burned();
        StopToWalk();
        yield return new WaitForSeconds(3);

        // TODO: Set originalMaterialMeshes into _meshes
        for (int i = 0; i < _meshes.Length; i++)
        {
            _meshes[i].material = _originalMaterialMeshes[i];
        }

        StartToWalk();
        // Call inmunity animation
        yield return new WaitForSeconds(1.5f);
        _inmunity = false;
        
    }

}
