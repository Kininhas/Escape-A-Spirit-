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
        // Verifica se já existe uma instância do MusicController e destroi o objeto atual
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Define a instância como esta
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Obtém o componente AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        // Registra o método OnSceneLoaded para ser chamado quando uma cena for carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se a cena carregada é a cena de "Settings" ou "a mapping choice"
        if (scene.name == "Settings" || scene.name == "a mapping choice")
        {
            // Se a música não estiver tocando, inicia a reprodução da música
            if (!audioSource.isPlaying)
            {
                PlayMusic();
            }
        }
        // Verifica se a cena carregada é a cena inicial
        else if (scene.name == "Main Menu")
        {
            // Se a música não estiver tocando, inicia a reprodução da música
            if (!audioSource.isPlaying)
            {
                PlayMusic();
            }
        }
        else
        {
            // Se a música estiver tocando, para a reprodução da música
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }



    private void PlayMusic()
    {
        // Inicia a reprodução da música se ela não estiver tocando
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        // Para a reprodução da música
        audioSource.Stop();
    }
}
