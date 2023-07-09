using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSource;

    private void Awake()
    {
        // Verifica se j� existe uma inst�ncia do MusicController e destroi o objeto atual
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Define a inst�ncia como esta
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Obt�m o componente AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        // Registra o m�todo OnSceneLoaded para ser chamado quando uma cena for carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se a cena carregada � a cena de "Settings" ou "a mapping choice"
        if (scene.name == "Settings" || scene.name == "a mapping choice")
        {
            // Se a m�sica n�o estiver tocando, inicia a reprodu��o da m�sica
            if (!audioSource.isPlaying)
            {
                PlayMusic();
            }
        }
        // Verifica se a cena carregada � a cena inicial
        else if (scene.name == "Main Menu")
        {
            // Se a m�sica n�o estiver tocando, inicia a reprodu��o da m�sica
            if (!audioSource.isPlaying)
            {
                PlayMusic();
            }
        }
        else
        {
            // Se a m�sica estiver tocando, para a reprodu��o da m�sica
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }



    private void PlayMusic()
    {
        // Inicia a reprodu��o da m�sica se ela n�o estiver tocando
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        // Para a reprodu��o da m�sica
        audioSource.Stop();
    }
}
