using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private PlayerShoot ps;
    private SpellManager sm;

    void Start()
    {
        ps = FindObjectOfType<PlayerShoot>();
        sm = FindObjectOfType<SpellManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ps.canShoot = false;
        sm.selecting = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ps.shotIndex == 1)
        {
            if (sm.numR >= 1)
            {
                ps.canShoot = true;
            }
        }
        else if (ps.shotIndex == 2)
        {
            if (sm.numH >= 1)
            {
                ps.canShoot = true;
            }
        }
        else
        {
            ps.canShoot = true;
        }
        sm.selecting = false;
    }
}
