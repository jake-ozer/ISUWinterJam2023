using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
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
            Debug.Log("Fireball destroyed");
            Destroy(gameObject);
        }
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
