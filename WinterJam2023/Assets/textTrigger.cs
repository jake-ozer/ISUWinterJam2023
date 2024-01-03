using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrigger : MonoBehaviour
{
    public Animator textBox1;
    public Animator textBox2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textBox1.SetBool("IsActive", true);
        textBox2.SetBool("IsActive", true);
    }
}
