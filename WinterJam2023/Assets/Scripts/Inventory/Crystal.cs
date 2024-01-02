using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public AudioClip pickupClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<CrystalPortal>().numCrystals++;
            FindObjectOfType<SoundManager>().PlaySound(pickupClip);
            Destroy(gameObject);
        }
    }
}
