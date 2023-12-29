using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pushDelay = 0.12f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PushEnemy(float pushForce, Vector3 dir)
    {
        GetComponent<AIPath>().enabled = false;
        rb.AddForce(dir * pushForce, ForceMode2D.Impulse);
        StartCoroutine("Push");
    }

    private IEnumerator Push()
    {
        yield return new WaitForSeconds(pushDelay);
        rb.velocity = Vector3.zero;
        GetComponent<AIPath>().enabled = true;
    }
}
