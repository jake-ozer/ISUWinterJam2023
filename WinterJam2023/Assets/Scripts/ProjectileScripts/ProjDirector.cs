using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjDirector : MonoBehaviour
{
    public float speed = 10f;
    public float destroyAfterTime;
    public Vector3 direction;

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

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
