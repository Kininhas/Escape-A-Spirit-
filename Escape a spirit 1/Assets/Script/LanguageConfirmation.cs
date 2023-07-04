using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageConfirmation : MonoBehaviour
{
    public Text confirmationText;

    private SupportedLanguage selectedLanguage;

    public void ShowConfirmation(SupportedLanguage language)
    {
        selectedLanguage = language;
        confirmationText.text = "Are you sure you want to change the language to " + language.ToString() + "?";
        gameObject.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
