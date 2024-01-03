using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : MonoBehaviour
{
    public CrystalPortal Portal;
    public Animator textBox1;
    public Animator textBox2;
    private bool done;

    private void Start()
    {
        done = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Portal.open == true && done == false)
        {
            textBox1.SetBool("IsActive", true);
            textBox2.SetBool("IsActive", true);
            done = true;
        }
    }
}
