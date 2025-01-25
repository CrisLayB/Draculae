using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private float cutsceneTime = 5f;
    [SerializeField] private InputConfig playerInput;
    private List<GameObject> _childObjects = new List<GameObject>();
    private bool _allowContinue = false;

    private void Start()
    {    
        GetChildObjectsRecursive(this.gameObject);
        
        for (int i = 0; i < _childObjects.Count; i++)
        {
            if (i == 0) continue;

            _childObjects[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (!_allowContinue) return;

        if (
            Input.GetKeyDown(playerInput.action.keyboardKey) ||
            Input.GetKeyDown(playerInput.action.controllerButton) ||
            Input.GetKeyDown(KeyCode.Return)
        )
        {
            // Reset Game
            SceneManager.LoadScene("MainGame");
        }
    }

    public void CutsceneStart()
    {
        StartCoroutine(RunCutsceneBeforeResults());
    }

    private IEnumerator RunCutsceneBeforeResults()
    {
        yield return new WaitForSeconds(cutsceneTime);

        // Activa los objetos hijos
        foreach (GameObject child in _childObjects)
        {
            child.SetActive(true);
        }

        _allowContinue = true;

        // TODO: Set Results of the game
    }

    private void GetChildObjectsRecursive(GameObject parent)
    {
        _childObjects.Add(parent);

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            GetChildObjectsRecursive(child);
        }
    }
}
