using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SupportedLanguageEnum
{
    French,
    English,
    Spanish,
    Portuguese,
    Korean
}

public class TranslateButton : MonoBehaviour
{
    public string translationKey;

    private Button button;
    private Text buttonText;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>();

        // Inscrever-se ao evento de mudan�a de idioma
        LanguageSelection.instance.OnLanguageChange += UpdateButtonText;

        // Atualizar o texto traduzido inicialmente
        UpdateButtonText();
    }

    private void OnDestroy()
    {
        // Remover a inscri��o ao destruir o componente
        LanguageSelection.instance.OnLanguageChange -= UpdateButtonText;
    }

    private void UpdateButtonText()
    {
        if (!string.IsNullOrEmpty(translationKey))
        {
            string translatedText = LanguageSelection.instance.GetTranslation(translationKey);
            buttonText.text = translatedText;
        }
        else
        {
            Debug.LogWarning("Chave de tradu��o n�o definida para o bot�o.");
        }
    }
}