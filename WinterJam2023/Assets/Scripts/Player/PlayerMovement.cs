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

        if (playerControls.general.sprint.IsPressed())
        {
            modifier = sprintModifier;
        }
        else
        {
            modifier = 1;
        }
    }

}
