using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject curShot;
    public GameObject[] shotOptions;
    public int shotIndex = 0;

    private Camera mainCamera;

    private PlayerControls playerControls;

    public Animator anim;
    public bool canShoot = true;

    public AudioClip shotSound;

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

    bool once = true;
    private void Update()
    {
        curShot = shotOptions[shotIndex];

        if (playerControls.general.fire.triggered && canShoot)
        {
            SpawnFireball();
            anim.SetTrigger("shoot");
        }

        //show health bar for allies when heal spell is selected
        if (shotIndex == 2 && once)
        {
            Ally[] allies = FindObjectsOfType<Ally>();
            foreach (Ally ally in allies)
            {
                ally.gameObject.GetComponent<NPC>().FlashHealthBar();
            }
            once = false;
        }
        else
        {
            once = true;
        }
    }

    public void SpawnFireball()
    {
        FindObjectOfType<SoundManager>().PlaySound(shotSound);

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
