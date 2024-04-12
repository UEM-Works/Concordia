using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdditiveScene : MonoBehaviour
{
    public string additiveSceneName;
    public Canvas initialCanvas;

    public void _LoadAdditiveScene()
    {
        SceneManager.LoadScene(additiveSceneName, LoadSceneMode.Additive);
        initialCanvas.enabled = false;
    }

    public void _UnloadAdditiveScene()
    {
        SceneManager.UnloadScene(additiveSceneName);

        FindObjectOfType<Canvas>().enabled = true;
    }
}
