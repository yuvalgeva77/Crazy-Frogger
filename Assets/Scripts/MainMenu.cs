using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//in order to change scenes
//using UnityEditor;

public class MainMenu : MonoBehaviour
{//press play
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
