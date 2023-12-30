using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBattleHandler : MonoBehaviour
{
    public bool isAlly = false;
    public float attackDamage = 10f;
    public float knocback = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ally")
        {
            //initial damage
            if (isAlly)
            {
                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(attackDamage);
                }
            }
            else
            {
                if (collision.gameObject.tag == "Ally")
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(attackDamage);
                }
            }

            //knockback
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                var foe = collision.gameObject;
                foe.GetComponent<NPC>().PushEnemy(knocback, Vector2.right);
            }
            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                var foe = collision.gameObject;
                foe.GetComponent<NPC>().PushEnemy(knocback, Vector2.left);
            }
        }

        
    }
}
