using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject curShot;
    public GameObject[] shotOptions;
    private int shotIndex = 0;

    private Camera mainCamera;

    private PlayerControls playerControls;

    public Animator anim;

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

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (playerControls.general.fire.triggered)
        {
            SpawnFireball();
            anim.SetTrigger("shoot");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotIndex++;
            if (shotIndex >= shotOptions.Length)
            {
                shotIndex = 0;
            }
            curShot = shotOptions[shotIndex];
        }
    }

    public void SpawnFireball()
    {

        Vector3 mousePosition = Input.mousePosition;
        // Convert mouse position from screen space to world space
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calculate direction from the player to the mouse position
        Vector2 direction = (worldMousePosition - transform.position).normalized;


        // Instantiate the fireball and set its direction
        GameObject newProj = Instantiate(curShot, transform.position, Quaternion.identity);
        newProj.GetComponent<ProjDirector>().SetDirection(direction);
    }
}
