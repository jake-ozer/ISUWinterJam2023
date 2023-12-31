using System.Collections;
using System.Collections.Generic;
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
        }
        else
        {
            modifier = 1;
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
