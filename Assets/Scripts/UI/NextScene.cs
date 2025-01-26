using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int seconds = 5;
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] private bool skipableCutscene = false;
    [SerializeField] private InputConfig playerInput;

    private void Start() 
    {
        StartCoroutine(GoToNextScene());
    }

    private void Update() 
    {
        if(!skipableCutscene) return;

        if(playerInput == null)
        {
            Debug.LogError("No InputConfig assigned to NextScene.");
            return;
        }

        if(Input.GetKeyDown(playerInput.action.keyboardKey) || Input.GetKeyDown(playerInput.action.controllerButton))
        {
            unityEvent?.Invoke();
        }
    }

    private IEnumerator GoToNextScene()
    {        
        yield return new WaitForSeconds(seconds);
        unityEvent?.Invoke();
    }
}
