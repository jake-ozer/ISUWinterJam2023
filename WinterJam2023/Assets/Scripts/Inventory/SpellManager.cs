using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    public float numR;
    public float numH;
    public PlayerShoot playerShoot;

    public GameObject resButton;
    public GameObject healButton;
    public bool selecting = false;

    private void Update()
    {
        resButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "x"+ numR.ToString();
        healButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "x"+ numH.ToString();

        if (numR < 0)
        {
            numR = 0;
        }

        if (numH < 0)
        {
            numH = 0;
        }

        if (numR <= 0)
        {
            resButton.GetComponent<Button>().interactable = false;
            if (playerShoot.shotIndex == 1)
            {
                playerShoot.canShoot = false;
            }
        }
        if (numR > 0 && !selecting)
        {
            resButton.GetComponent<Button>().interactable = true;
            if (playerShoot.shotIndex == 1)
            {
                playerShoot.canShoot = true;
            }
        }

        if (numH <= 0)
        {
            healButton.GetComponent<Button>().interactable = false;
            if (playerShoot.shotIndex == 2)
            {
                playerShoot.canShoot = false;
            }
        }
        if (numH > 0 && !selecting)
        {
            healButton.GetComponent<Button>().interactable = true;
            if (playerShoot.shotIndex == 2)
            {
                playerShoot.canShoot = true;
            }
        }
    }

    public void SwitchToFireball()
    {
        playerShoot.shotIndex = 0;
        playerShoot.canShoot = true;
    }

    public void SwitchToRes()
    {
        playerShoot.shotIndex = 1;
    }

    public void SwitchToHeal()
    {
        playerShoot.shotIndex = 2;
    }
}
