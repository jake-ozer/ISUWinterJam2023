using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage;
    public float knockback;
    public float destroyAfterTime;
    private Vector3 direction;

    private void Start()
    {
        Invoke("DestroyAfterTime", destroyAfterTime);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        direction.z = 0;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            collision.gameObject.GetComponent<NPC>().PushEnemy(knockback, direction);
            Destroy(gameObject);
        }
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
