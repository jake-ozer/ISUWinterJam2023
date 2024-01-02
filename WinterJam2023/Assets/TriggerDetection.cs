using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public bool triggerIsActive;

    // Start is called before the first frame update
    void Start()
    {
        triggerIsActive = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
