using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage;
    public float knockback;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject childObject = collision.gameObject;
            GameObject parentObject = null;
            if (childObject.transform.parent != null)
            {
                parentObject = collision.transform.parent.gameObject;
            }

            if (parentObject == null)
            {
                childObject.GetComponent<Health>().TakeDamage(damage);
                childObject.GetComponent<NPC>().PushEnemy(knockback, GetComponent<ProjDirector>().direction);
            }
            else
            {
                parentObject.GetComponent<Health>().TakeDamage(damage);
                parentObject.GetComponent<NPC>().PushEnemy(knockback, GetComponent<ProjDirector>().direction);
            }

           
            Destroy(gameObject);
        }
    }
}
