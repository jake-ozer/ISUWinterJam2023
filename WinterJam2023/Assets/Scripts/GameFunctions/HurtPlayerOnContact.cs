using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool on = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (on)
            {
                GameObject.Find("Player").GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
