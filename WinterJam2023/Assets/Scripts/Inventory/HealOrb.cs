using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOrb : MonoBehaviour
{
    public int numOrbs;
    public AudioClip orbClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<SpellManager>().numH += numOrbs;
            FindObjectOfType<SoundManager>().PlaySound(orbClip);
            Destroy(this.gameObject);
        }
    }
}
