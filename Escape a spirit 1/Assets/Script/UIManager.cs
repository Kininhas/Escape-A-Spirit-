using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject languageMenu;
    public GameObject controlMenu;
    public GameObject videoMenu;
    public GameObject audioMenu;

    private GameObject activeMenu;

    private void Start()
    {
        // No início, mostramos apenas o menu de idiomas
        ShowLanguageMenu();
    }

    public void ShowLanguageMenu()
    {
        if (activeMenu != languageMenu)
        {
            HideMenusExcept(languageMenu);
            Debug.Log("Tela: Idiomas");
        }
    }

    public void ShowControlMenu()
    {
        if (activeMenu != controlMenu)
        {
            HideMenusExcept(controlMenu);
            Debug.Log("Tela: Controles");
        }
    }

    public void ShowVideoMenu()
    {
        if (activeMenu != videoMenu)
        {
            HideMenusExcept(videoMenu);
            Debug.Log("Tela: Vídeo");
        }
    }

    public void ShowAudioMenu()
    {
        if (activeMenu != audioMenu)
        {
            HideMenusExcept(audioMenu);
            Debug.Log("Tela: Áudio");
        }
    }

    private void HideMenusExcept(GameObject menuToKeepVisible)
    {
        if (activeMenu != null)
        {
            activeMenu.SetActive(true);
        }

        menuToKeepVisible.SetActive(true);
        activeMenu = menuToKeepVisible;
    }
}
