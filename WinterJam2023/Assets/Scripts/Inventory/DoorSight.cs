using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSight : MonoBehaviour
{
    public CrystalPortal cp;
    public Animator anim;
    public GameObject arrow;
    public AudioClip openClip;
    private bool once = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && cp.numCrystals >= cp.crystalsNeeded && once)
        {
            FindObjectOfType<SoundManager>().PlaySound(openClip);
            anim.SetTrigger("openDoor");
            arrow.SetActive(false);
            once = false;
        }
    }
}
