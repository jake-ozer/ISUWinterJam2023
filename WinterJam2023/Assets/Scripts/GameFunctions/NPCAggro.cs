using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Rendering.InspectorCurveEditor;

public class NPCAggro : MonoBehaviour
{
    public bool isAlly;
    public bool playerOnly;
    [SerializeField] private AIDestinationSetter aiDes;
    private bool targetLocked = false;
    public Ally ally;
    private GameObject targetGameObject;
    private NPCStateController.NPCState targetState;

    private void Start()
    {
        targetGameObject = null;
    }

    private void Update()
    {

        if (aiDes.target == null && ally != null)
        {
            targetLocked = false;
            ally.followingPlayer = true;
        }

        

        //for retargeting after target is dead
        if (targetGameObject != null)
        {
            if (targetGameObject.transform.parent != null) //this happens once
            {
                if (targetGameObject.GetComponent<NPCStateController>() == null)
                {
                    targetGameObject = targetGameObject.transform.parent.gameObject;
                }
            }

            if (targetGameObject.GetComponent<NPCStateController>() != null)
            {
                targetState = targetGameObject.GetComponent<NPCStateController>().curState;
                if (targetState == NPCStateController.NPCState.dead)
                {
                    aiDes.target = null;
                    targetGameObject = null;

                    //reset collider so it can retarget on something else if possible
                    GetComponent<Collider2D>().enabled = false;
                    GetComponent<Collider2D>().enabled = true;
                }
            }
    
        }

    }


    //need some if conditions here connecting to state controller to dertimine aggro on others
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!targetLocked && isAlly || aiDes.target == null)
        {
            if (isAlly)
            {   
                if (collision.gameObject.tag == "Enemy")
                {
                    ally.followingPlayer = false;
                    targetLocked = true;
                    aiDes.target = collision.gameObject.transform;
                    targetGameObject = collision.gameObject;
                }
            }
            else
            {
                if (playerOnly)
                {
                    if (collision.gameObject.tag == "Player")
                    {
                        aiDes.target = collision.gameObject.transform;
                        targetGameObject = collision.gameObject;
                    }
                }
                else
                {
                    if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ally")
                    {
                        aiDes.target = collision.gameObject.transform;
                        targetGameObject = collision.gameObject;
                    }
                }
            }
        }
    }
}
