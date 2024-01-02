using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalPortal : MonoBehaviour
{
    public bool open = false;
    private CrystalManager cManager;
    public int numCrystals;
    public int crystalsNeeded;

    private void Awake()
    {
        cManager = FindObjectOfType<CrystalManager>();
    }

    private void Update()
    {
        if (numCrystals >= crystalsNeeded)
        {
            open = true;
        }
        else
        {
            open = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && open)
        {
            Debug.Log("YOU win, good job");
        }
    }
}
