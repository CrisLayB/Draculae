using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesHandlerManager : MonoBehaviour
{
    public void IntroductionCutScene()
    {
        SceneManager.LoadScene("Cinematicas");
    }
    
    public void ResetMainGame()
    {   
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
