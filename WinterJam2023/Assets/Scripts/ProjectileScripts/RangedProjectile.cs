using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    private Vector3 direction;
    public void SetDir(Vector3 direction) => this.direction = direction;
    public float destroyAfterTime;
    public float speed;
    public float damage;
    public float pushForce = 5f;
    public bool allyShot;


    private void Start()
    {
        Invoke("DestroyAfterTime", destroyAfterTime);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!allyShot)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ally")
            {
                if (collision.gameObject.GetComponent<Health>() != null)
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                    NPC npc = collision.GetComponent<NPC>();
                    if (npc != null)
                    {
                        //npc.PushEnemy(pushForce, new Vector3(1, 0, 0));
                    }
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (collision.gameObject.GetComponent<Health>() != null)
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                    NPC npc = collision.GetComponent<NPC>();
                    if (npc != null)
                    {
                        //npc.PushEnemy(pushForce, new Vector3(1, 0, 0));
                    }
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }

        
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
