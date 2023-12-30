using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessurectionOrbs : MonoBehaviour
{
    RessurectionCounter ressurectionCounter;

    private void Awake()
    {
        ressurectionCounter = GameObject.Find("Game Manager").GetComponent<RessurectionCounter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ressurectionCounter.uses += 1f;

            Destroy(this.gameObject);
        }
    }
}
