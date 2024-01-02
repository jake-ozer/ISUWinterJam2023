using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseManager : MonoBehaviour
{
    //f anyone reads this script, im sorry its so spagehetti, it was end of game jam ;(

    public GameObject pauseMenu;
    private PlayerControls playerControls;
    public AudioClip pauseClip;
    public LevelManager levelManager;
    public bool usable = true;

    //scene trans anim
    public Animator fadeAnimator;
    [SerializeField] bool animDone;
    public delegate void SceneChoice();
    public SceneChoice curSceneChoice;

    private void Awake()
    {
        playerControls = new PlayerControls();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        animDone = false;
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
            usable = false;
        }

        animDone = fadeAnimator.GetBool("Transition");
        if (animDone == true)
        {
            curSceneChoice.Invoke();
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
        usable = true;
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

    public void TriggerSceneTransAnim()
    {
        fadeAnimator.SetBool("Fade", true);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        levelManager.ResetScene();
    }

    //CHOICE METHODS (for button OnClicks)
    public void ChooseNextScene()
    {
        curSceneChoice = NextScene;
        TriggerSceneTransAnim();
    }

    public void ChooseGenLevel()
    {
        curSceneChoice = LoadGenLevel;
        TriggerSceneTransAnim();
    }

    public void ChooseMenuLevel()
    {
        curSceneChoice = QuitToMenu;
        TriggerSceneTransAnim();
    }

    public void ChooseResetScene()
    {
        curSceneChoice = ResetLevel;
        TriggerSceneTransAnim();
    }

}
