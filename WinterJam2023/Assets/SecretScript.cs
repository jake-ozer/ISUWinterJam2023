using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretScript : MonoBehaviour
{
    public Animator secretAnimation;
    [SerializeField] bool wasActive;
    // Start is called before the first frame update
    void Start()
    {
        wasActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wasActive == true)
        {
            secretAnimation.SetBool("KeycodeEntered", false);
            wasActive = false;
        }
        if (secretAnimation.GetBool("KeycodeEntered") == true)
        {
            wasActive = true;
        }
    }

    public void SecretActivated()
    {
        secretAnimation.SetBool("KeycodeEntered", true);
    }
}
