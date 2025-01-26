using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void WalkingAnimation(float movement)
    {
        animator.SetFloat("movement", movement);
    }

    public void GetCoin()
    {
        animator.SetTrigger("grab");
    }

    public void ThrowCoin()
    {
        animator.SetTrigger("throw");
    }

    public void DanceChoice()
    {
        animator.SetInteger("typeDance", Random.Range(1, 3));
    }

    public void Burned()
    {
        animator.SetTrigger("burned");
    }
}
