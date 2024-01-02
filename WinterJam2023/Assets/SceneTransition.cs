using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //Enter the next scene here
    [SerializeField] int targetSceneID;

    public void SceneChange()
    {
        SceneManager.LoadScene(targetSceneID);
    }
}
