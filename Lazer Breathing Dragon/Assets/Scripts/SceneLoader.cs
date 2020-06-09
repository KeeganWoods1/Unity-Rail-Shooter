using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [Tooltip("In seconds")] [SerializeField] double endGameTime = 103f;
    PlayableDirector playableDirector;

    bool isGameScene = false;



    // Start is called before the first frame update
    void Start()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {

            Invoke("LoadNextScene", 3);
        }

        else
        {
            playableDirector = GetComponent<PlayableDirector>();
            isGameScene = true;
        }

    }

    private void Update()
    {
        if (isGameScene)
        {
            CheckReloadSplash();
        }

    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void CheckReloadSplash()
    {
        double currentTime = playableDirector.time;

        if (currentTime >= endGameTime)
        {     
            SceneManager.LoadScene(0);
        }
    }
}
