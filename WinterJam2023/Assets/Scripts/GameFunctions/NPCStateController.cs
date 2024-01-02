using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class NPCStateController : MonoBehaviour
{
    public enum NPCState
    {
        enemy,
        dead,
        ally
    }

    public NPCState curState;

    //references for modifications
    public GameObject damageBox;
    public NPCAggro aggro;
    public GameObject battleHandler;
    public Image barFill;
    public Color enemyCol;
    public Color allyCol;
    public GameObject allyIcon;
    public AIPath aiPath;
    public GameObject followBox;

    public Ally allyScript;
    public Animator anim;

    public float timeTillDespawn = 20f;


    private void Start()
    {
        curState = NPCState.enemy;
    }

    bool once = true;
    bool onceForRestore = true;
    private void Update()
    {
        switch (curState)
        {
            case NPCState.enemy:
                damageBox.SetActive(true);
                aggro.isAlly = false;
                barFill.color = enemyCol;
                allyScript.enabled = false;
                gameObject.tag = "Enemy";
                battleHandler.tag = "Enemy";
                battleHandler.GetComponent<NPCBattleHandler>().isAlly = false;
                aiPath.enabled = true;
                anim.SetBool("dead", false);
                if (GetComponent<RangedEnemy>() != null)
                {
                    GetComponent<RangedEnemy>().enabled = true;
                }
                StopAllCoroutines();
                once = true;
                battleHandler.GetComponent<Collider2D>().enabled = true;
                allyIcon.SetActive(false);
                break;
            case NPCState.dead:
                aiPath.enabled = false;
                anim.SetBool("dead", true);
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                gameObject.tag = "Dead";
                damageBox.SetActive(false);
                if (GetComponent<RangedEnemy>() != null)
                {
                    GetComponent<RangedEnemy>().enabled = false;
                }
                if (once)
                {
                    StartCoroutine("Despawn");
                    once = false;
                }
                battleHandler.GetComponent<Collider2D>().enabled = false;
                allyIcon.SetActive(false);
                onceForRestore = true;
                followBox.SetActive(false);
                if (GetComponent<Ally>() != null)
                {
                    GetComponent<Ally>().followingPlayer = false;
                }
                break;
            case NPCState.ally:
                damageBox.SetActive(false);
                aggro.isAlly = true;
                barFill.color = allyCol;
                allyScript.enabled = true;
                gameObject.tag = "Ally";
                battleHandler.tag = "Ally";
                battleHandler.GetComponent<NPCBattleHandler>().isAlly = true;
                aiPath.enabled = true;
                anim.SetBool("dead", false);
                if (GetComponent<RangedEnemy>() != null)
                {
                    GetComponent<RangedEnemy>().enabled = true;
                }
                StopAllCoroutines();
                once = true;
                battleHandler.GetComponent<Collider2D>().enabled = true;
                if (onceForRestore)
                {
                    GetComponent<Health>().RestoreHealthToFull();
                    if (GetComponent<Ally>() != null)
                    {
                        GetComponent<Ally>().followingPlayer = true;
                    }
                    onceForRestore = false;
                }
                allyIcon.SetActive(true);
                break;
        }
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(timeTillDespawn);
        Destroy(gameObject);
    }
}
