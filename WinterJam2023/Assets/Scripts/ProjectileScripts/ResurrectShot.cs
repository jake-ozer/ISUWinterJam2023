using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Dead")
        {
            GameObject childObject = collision.gameObject;
            GameObject parentObject = null;
            if (childObject.transform.parent != null)
            {
                parentObject = collision.transform.parent.gameObject;
            }

            if (parentObject == null)
            {
                childObject.GetComponent<NPCStateController>().curState = NPCStateController.NPCState.ally;
            }
            else
            {
                parentObject.GetComponent<NPCStateController>().curState = NPCStateController.NPCState.ally;
            }


            Destroy(gameObject);
        }
    }
}


