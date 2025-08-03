using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SManeger : MonoBehaviour
{
    public void PlayGame()
    {
        // calling first sence
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        // closing game 
        Application.Quit();
    }
}
