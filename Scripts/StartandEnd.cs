using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartandEnd : MonoBehaviour
{
    public void startMenu()
    {
        SceneManager.LoadScene(23);
    }
    
    public void exitMenu()
    {
        Application.Quit();
    }
}
