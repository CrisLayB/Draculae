using UnityEngine;

[System.Serializable]
public struct InputAction
{
    public KeyCode keyboardKey;
    public KeyCode controllerButton;
}

[CreateAssetMenu(fileName = "InputConfig", menuName = "ScriptableObjects/InputConfig")]
public class InputConfig : ScriptableObject
{
    public string verticalAxis;
    public string horizontalAxis;
    public InputAction action;    
}