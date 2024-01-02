using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDetection : MonoBehaviour
{
    public int crystalNearby;
    public Animator detectorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        crystalNearby = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "OuterRadius" && crystalNearby < 1)
        {
            crystalNearby = 1;
        }
        if (other.tag == "MiddleRadius" && crystalNearby < 2)
        {
            crystalNearby = 2;
        }
        if (other.tag == "InnerRadius" && crystalNearby < 3)
        {
            crystalNearby = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "InnerRadius" && crystalNearby > 2)
        {
            crystalNearby = 2;
        }
        if (other.tag == "MiddleRadius" && crystalNearby > 1)
        {
            crystalNearby = 1;
        }
        if (other.tag == "OuterRadius" && crystalNearby > 0)
        {
            crystalNearby = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        detectorAnimator.SetInteger("CrystalNearby", crystalNearby);
    }
}
