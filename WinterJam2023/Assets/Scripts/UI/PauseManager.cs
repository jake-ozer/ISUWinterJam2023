using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private PlayerControls playerControls;
    public AudioClip pauseClip;

    private void Awake()
    {
        playerControls = new PlayerControls();
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
        if (playerControls.general.pause.triggered)
        {
            FindObjectOfType<SoundManager>().PlaySound(pauseClip);
            PauseGame();
        }
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

    public void QuitGame()
    {
        Debug.Log("You quit the game");
        Application.Quit();
    }
}
