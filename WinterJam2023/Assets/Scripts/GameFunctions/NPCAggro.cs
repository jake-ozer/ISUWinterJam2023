using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAggro : MonoBehaviour
{
    public bool isAlly;
    public bool playerOnly;
    [SerializeField] private AIDestinationSetter aiDes;
    private bool targetLocked = false;
    public Ally ally;


    private void Update()
    {
        if (aiDes.target == null && ally != null)
        {
            targetLocked = false;
            ally.followingPlayer = true;
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
                }
            }
            else
            {
                if (playerOnly)
                {
                    if (collision.gameObject.tag == "Player")
                    {
                        aiDes.target = collision.gameObject.transform;
                    }
                }
                else
                {
                    if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ally")
                    {
                        aiDes.target = collision.gameObject.transform;
                    }
                }
            }
        }
    }
}
