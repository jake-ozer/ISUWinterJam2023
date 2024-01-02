using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    private int sceneIndex = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadTutorial()
    {
        sceneIndex = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadGenLevel()
    {
        sceneIndex = 2;
        SceneManager.LoadScene(2);
    }

    public void NextScene()
    {
        sceneIndex++;
        if (sceneIndex > 2)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game");
        Application.Quit();
    }
}
