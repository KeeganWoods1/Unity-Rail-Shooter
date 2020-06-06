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
        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();

        Invoke("LoadNextScene", 3); 
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
