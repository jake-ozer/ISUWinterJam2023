using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private float textTimer;
    [SerializeField] float textTransitionTime;
    private int textState;

    //public List<Animator> textBoxes = new List<Animator>();
    public Animator textBox1;
    public Animator textBox2;
    public Animator textBox3;
    public Animator textBox4;

    private int lastActivated;
    private int lastDeactivated;


    // Start is called before the first frame update
    void Start()
    {
        textTimer = 0;
        textState = 0;
        lastActivated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (textTimer > 0)
        {
            textTimer -= Time.deltaTime;
        }
        if (textState == 0)
        {
            textBox1.SetBool("IsActive", true);
            textBox2.SetBool("IsActive", true);
            textTimer = textTransitionTime;
            textState = 1;
        }
        if (textState == 1 && textTimer <= 0)
        {
            textBox3.SetBool("IsActive", true);
            textBox4.SetBool("IsActive", true);
        }
    }

    /*public void TextEnable()
    {
        GetAnimator(lastActivated);

        lastActivated += 1;
    }

    public Animator GetAnimator(int index)
    {
        // this returns the gameobject that exists at "index" position.
        // This means, if index is 0, the first object added will be returned, 1 means the one after that and so on.
        return textBoxes[index];
    }*/
}
