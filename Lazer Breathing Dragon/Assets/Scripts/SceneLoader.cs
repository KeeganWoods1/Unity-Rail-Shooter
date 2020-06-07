using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (currentSceneIndex == 0)
        {
            Invoke("LoadNextScene", 3);
        }

    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
