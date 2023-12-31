using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pushDelay = 0.12f;
    bool facingRight = false;
    private GameObject player;
    public Animator anim;
    public GameObject gfx;
    public GameObject healthBar;
    private Coroutine showBar;

    public AIPath aiPath;
    public AIDestinationSetter aiDes;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    public void PushEnemy(float pushForce, Vector3 dir)
    {
        GetComponent<AIPath>().enabled = false;
        rb.AddForce(dir * pushForce);
        StartCoroutine("Push");
    }

    private IEnumerator Push()
    {
        yield return new WaitForSeconds(pushDelay);
        rb.velocity = Vector3.zero;
        GetComponent<AIPath>().enabled = true;
    }

    private IEnumerator ShowBar()
    {
        healthBar.SetActive(true);
        yield return new WaitForSeconds(3f);
        healthBar.SetActive(false);
    }

    public void FlashHealthBar()
    {
        if (showBar != null)
        {
            StopCoroutine(showBar);
        }
        showBar = StartCoroutine("ShowBar");
    }

    private void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                gfx.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (player.transform.position.x <= transform.position.x )
            {
                gfx.transform.localScale = new Vector3(1, 1, 1);
            }
        }


        if (aiPath.reachedDestination || aiDes.target == null)
        {
            anim.SetBool("walking", false);
        }
        else
        {
            anim.SetBool("walking", true);
        }
    }
}
