using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform target; 
    public float stoppingDuration = 1.5f; // Duration to consider the enemy stopped
    public float shootingCooldown = 1.5f; // Cooldown between shots
    public GameObject projectile;
    public AIDestinationSetter aiDes;

    private Vector3 previousPosition;
    private float timer = 0f;
    private bool isShooting = false;
    private float shootingTimer = 0f;

    void Start()
    {
        previousPosition = transform.position;
        shootingTimer = shootingCooldown;
    }

    void Update()
    {
        target = aiDes.target;

        if (target != null)
        {
            if (transform.position != previousPosition)
            {
                // Enemy is moving, reset the timer
                timer = 0f;
                shootingTimer = shootingCooldown;
            }
            else
            {
                // Enemy is not moving, start counting time
                timer += Time.deltaTime;

                if (timer >= stoppingDuration)
                {
                    // Enemy has stopped for the specified duration, start shooting
                    if (!isShooting)
                    {
                        isShooting = true;
                        // Start shooting or continue shooting logic here
                    }

                    // Shooting cooldown timer
                    shootingTimer += Time.deltaTime;
                    if (shootingTimer >= shootingCooldown)
                    {
                        Shoot(); // Call the shoot method
                        shootingTimer = 0f; // Reset the shooting timer
                    }
                }
            }

            // Update the previous position
            previousPosition = transform.position;
        }
    }

    void Shoot()
    {
        var proj = Instantiate(projectile, this.transform.position, Quaternion.identity);
        var direction = (target.position - transform.position).normalized;
        proj.GetComponent<RangedProjectile>().SetDir(direction);
    }
}
