using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private float cutsceneTime = 5f;
    [SerializeField] private InputConfig playerInput;
    [SerializeField] private UnityEvent _eventToPressContinue;

    [SerializeField] private Counter _counterPlayer1, _counterPlayer2;
    [SerializeField] private TMP_Text _winnerPlayer;
    [SerializeField] private TMP_Text _textCounterPlayer1, _textCounterPlayer2;
    
    private List<GameObject> _childObjects = new List<GameObject>();
    private bool _allowContinue = false;

    private void Start()
    {    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;        
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
            _eventToPressContinue?.Invoke();
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

        int pointsP1 = _counterPlayer1.CounCounter;
        int pointsP2 = _counterPlayer2.GetCoinCount();

        _winnerPlayer.text = pointsP1 < pointsP2? "Player 1 wins!" : pointsP2 < pointsP1? "Player 2 wins!" : "It's a tie!";
        
        _textCounterPlayer1.text = $"{pointsP1}";
        _textCounterPlayer2.text = $"{ pointsP2}";
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
