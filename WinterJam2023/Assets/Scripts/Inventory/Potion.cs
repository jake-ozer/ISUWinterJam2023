using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Health>().HealCheck())
        {
            collision.gameObject.GetComponent<Health>().AddHealth(healAmount);
            Destroy(this.gameObject);
        }
    }
}
