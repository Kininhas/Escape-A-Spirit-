using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    private MusicController musicController;

    private void Start()
    {
        musicController = MusicController.instance;
    }

    public void OnStartPlayButtonClicked()
    {
        musicController.StopMusic();
        SceneManager.LoadScene("a mapping choice");
    }
}
