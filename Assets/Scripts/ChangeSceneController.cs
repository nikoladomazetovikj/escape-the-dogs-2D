using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
