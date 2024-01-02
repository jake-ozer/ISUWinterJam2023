using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalPortal : MonoBehaviour
{
    public bool open = false;
    private CrystalManager cManager;
    public int numCrystals;
    public int crystalsNeeded;
    public GameObject arrow;
    public TextMeshProUGUI crystalText;
    public Animator SceneChange;

    private void Awake()
    {
        cManager = FindObjectOfType<CrystalManager>();
    }

    bool once = true;
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

        if (open && once)
        {
            arrow.SetActive(true);
            once = false;
        }

        crystalText.text = "Crsytals: " + numCrystals + "/" + crystalsNeeded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && open)
        {
            Debug.Log("YOU win, good job");
            Destroy(collision.gameObject);
            NPC[] npcs = FindObjectsOfType<NPC>();
            foreach (NPC npc in npcs)
            {
                Destroy(npc.gameObject);
            }
            SceneChange.SetBool("Fade", true);
        }
    }
}
