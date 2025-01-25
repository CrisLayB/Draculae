using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float highDistance = 0.7f;
    [SerializeField] private float distance = 1.5f;
    
    Vector3 positionFixed;
    
    private void FixedUpdate() 
    {
        positionFixed = new Vector3(transform.position.x, transform.position.y - highDistance, transform.position.z);        
        DetectCoin();
    }

    private void DetectCoin()
    {
        if(Physics.Raycast(positionFixed, transform.TransformDirection (Vector3.forward), out RaycastHit hitInfo, distance))
        {
            CoinActionToDo(hitInfo);
        }
        else
        {
            Debug.DrawRay(positionFixed, transform.TransformDirection(Vector3.forward) * distance, Color.green);
        }
    }

    private void CoinActionToDo(RaycastHit hitInfo)
    {
        Coin coin = hitInfo.collider.gameObject.GetComponent<Coin>();

        if(coin)
        {
            // Select Coin
            Debug.DrawRay(positionFixed, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        }
        else
        {
            // Deselect Coin
        }
    }
}
