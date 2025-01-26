using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCharacter : MonoBehaviour
{
    private AudioSource _stepSound;
    
    private void Start() 
    {
        _stepSound = GetComponent<AudioSource>();
    }
    
    public void StepSound()
    {
        _stepSound?.Play();
    }
}
