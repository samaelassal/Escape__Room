using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}