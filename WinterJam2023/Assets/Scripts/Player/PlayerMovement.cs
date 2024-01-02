using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprintModifier;
    private Rigidbody2D rb;
    private PlayerControls playerControls;
    private float modifier;
    private bool facingRight;
    public Animator anim;
    public GameObject playerGfx;
    public TextMeshProUGUI shiftText;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        var dir = playerControls.general.move.ReadValue<Vector2>();
        rb.velocity = dir * speed * modifier;

        if (dir != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (playerControls.general.sprint.IsPressed())
        {
            modifier = sprintModifier;
            shiftText.alpha = 0.3f;
        }
        else
        {
            modifier = 1;
            shiftText.alpha = 1f;
        }

        if (dir.x < 0)
        {
            facingRight = true;
        }
        if (dir.x > 0)
        {
            facingRight = false;
        }

        if (facingRight)
        {
            playerGfx.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerGfx.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
