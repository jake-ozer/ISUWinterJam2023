using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallHider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool showing = true;
    public GameObject cDetector;
    public string hideMessage;
    public string reShowMessage;
    public TextMeshProUGUI ballText;

    private void Update()
    {
        if (showing)
        {
            cDetector.SetActive(true);
        }
        else
        {
            cDetector.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FindAnyObjectByType<PlayerShoot>().canShoot = false;

        if (showing)
        {
            ballText.text = hideMessage;
        }
        else
        {
            ballText.text = reShowMessage;
        }

        ballText.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindAnyObjectByType<PlayerShoot>().canShoot = true;
        ballText.enabled = false;
    }

    public void ToggleShow()
    { 
        showing = !showing;
    }
}
