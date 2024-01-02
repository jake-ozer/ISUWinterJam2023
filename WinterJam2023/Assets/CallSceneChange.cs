using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSceneChange : MonoBehaviour
{
    public Animator fadeAnimation;
    public SceneTransition loadScript;
    [SerializeField] bool animDone;

    private void Start()
    {
        animDone = false;
    }
    // Update is called once per frame
    void Update()
    {
        animDone = fadeAnimation.GetBool("Transition");
        if (animDone == true)
        {
            FindObjectOfType<PauseManager>().NextScene();
        }
    }
}
