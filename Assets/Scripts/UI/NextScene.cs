using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int seconds = 5;
    [SerializeField] private UnityEvent unityEvent;

    private void Start() 
    {
        StartCoroutine(GoToNextScene());
    }

    private IEnumerator GoToNextScene()
    {        
        yield return new WaitForSeconds(seconds);
        unityEvent?.Invoke();
    }
}
