using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealShot : MonoBehaviour
{
    public float healAmount = 20f;
    public AudioClip healSound;

    private void Start()
    {
        FindObjectOfType<SpellManager>().numH--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ally")
        {
            GameObject childObject = collision.gameObject;
            GameObject parentObject = null;
            if (childObject.transform.parent != null)
            {
                parentObject = collision.transform.parent.gameObject;
            }
            if (parentObject == null)
            {
                childObject.GetComponent<Health>().AddHealth(healAmount);
            }
            else
            {
                parentObject.GetComponent<Health>().AddHealth(healAmount);
            }

            FindObjectOfType<SoundManager>().PlaySound(healSound);
            Destroy(gameObject);
        }
    }

}
