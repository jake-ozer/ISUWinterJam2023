using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private PlayerControls playerControls;
    public AudioClip pauseClip;
    public LevelManager levelManager;
    public bool usable = true;

    private void Awake()
    {
        playerControls = new PlayerControls();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        if (playerControls.general.pause.triggered && usable)
        {
            FindObjectOfType<SoundManager>().PlaySound(pauseClip);
            PauseGame();
        }
    }

    public void LoadGenLevel()
    {
        Time.timeScale = 1;
        levelManager.LoadGenLevel();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<PlayerShoot>().canShoot = true;
    }

    public void PauseGame()
    {
        FindObjectOfType<PlayerShoot>().canShoot = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextScene()
    {
        Time.timeScale = 1;
        levelManager.NextScene();
    }

    public void QuitToMenu()
    {
        levelManager.QuitToMainMenu();
    }

    public void QuitGame()
    {
        levelManager.QuitGame();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        levelManager.ResetScene();
    }
}
