using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;
    public GameObject textObject;
    public float delay = 1f;

    private void Start()
    {
        textObject.GetComponent<TextMeshProUGUI>().text = message;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("ShowMessage");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        textObject.SetActive(false);
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(delay);
        textObject.SetActive(true);
    }
}
