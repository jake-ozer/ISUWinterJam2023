using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool on = true;
    public float cooldownTime = 0.9f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (on)
            {
                GameObject.Find("Player").GetComponent<Health>().TakeDamage(damage);
                StartCoroutine("CoolDown");
            }
        }
    }

    private IEnumerator CoolDown()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(cooldownTime);
        GetComponent<Collider2D>().enabled = true;

    }
}
