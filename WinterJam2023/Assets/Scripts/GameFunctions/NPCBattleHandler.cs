using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCBattleHandler : MonoBehaviour
{
    public bool isAlly = false;
    public float attackDamage = 10f;
    public float knocback = 10f;
    public float cooldown = 0.9f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ally")
        {
            GameObject childObject = collision.gameObject;
            GameObject parentObject = null;
            if (childObject.transform.parent != null)
            {
                parentObject = collision.transform.parent.gameObject;
            }
            


            //initial damage
            if (isAlly)
            {
                if (collision.gameObject.tag == "Enemy")
                {

                    if (parentObject == null)
                    {
                        childObject.GetComponent<Health>().TakeDamage(attackDamage);
                    }
                    else
                    {
                        parentObject.GetComponent<Health>().TakeDamage(attackDamage);
                    }

                    //knockback
                    if (transform.position.x < collision.gameObject.transform.position.x)
                    {
                        //var foe = collision.gameObject;

                        if (parentObject == null)
                        {
                            childObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.right);
                        }
                        else
                        {
                            parentObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.right);
                        }
                    }
                    if (transform.position.x > collision.gameObject.transform.position.x)
                    {
                        //var foe = collision.gameObject;

                        if (parentObject == null)
                        {
                            childObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.left);
                        }
                        else
                        {
                            parentObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.left);
                        }
                    }
                }
            }
            else
            {
                if (collision.gameObject.tag == "Ally")
                {
                    if (parentObject == null)
                    {
                        childObject.GetComponent<Health>().TakeDamage(attackDamage);
                    }
                    else
                    {
                        parentObject.GetComponent<Health>().TakeDamage(attackDamage);
                    }

                    //knockback
                    if (transform.position.x < collision.gameObject.transform.position.x)
                    {
                        //var foe = collision.gameObject;

                        if (parentObject == null)
                        {
                            childObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.right);
                        }
                        else
                        {
                            parentObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.right);
                        }
                    }
                    if (transform.position.x > collision.gameObject.transform.position.x)
                    {
                        //var foe = collision.gameObject;

                        if (parentObject == null)
                        {
                            childObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.left);
                        }
                        else
                        {
                            parentObject.GetComponent<NPC>().PushEnemy(knocback, Vector2.left);
                        }
                    }
                }
            }

           

            //cooldown to allow for equal hits
            StartCoroutine("AttackCooldown");
        }
    }

    private IEnumerator AttackCooldown()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(cooldown);
        GetComponent<Collider2D>().enabled = true;
    }
}
