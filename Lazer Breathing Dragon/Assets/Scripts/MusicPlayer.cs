using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MusicPlayer : MonoBehaviour
{

    public static MusicPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();

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
