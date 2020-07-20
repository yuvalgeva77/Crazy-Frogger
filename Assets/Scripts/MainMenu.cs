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
    public void RestartGame()
    {
        Debug.Log("RESTART");
        //EditorApplication.isPlaying = false;
        timer gameTimer = GameObject.FindWithTag("timer").GetComponent<timer>();
        Debug.Log("RESTART");
        gameTimer.restart(0.2f);
    }
    public void back()
    {
        Debug.Log("back");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
