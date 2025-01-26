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

    public void CutsceneWinner(int result)
    {
        
        if(result == 1)
        {
            SceneManager.LoadScene("CinematicaFinalPlayer1Wins");
            return;
        }

        if(result == 2)
        {
            SceneManager.LoadScene("CinematicaFinalPlayer2Wins");
            return;
        }
        
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
