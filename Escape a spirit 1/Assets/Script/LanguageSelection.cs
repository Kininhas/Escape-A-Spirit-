using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SupportedLanguage
{
    French,
    English,
    Spanish,
    Portuguese
}

public class LanguageSelection : MonoBehaviour
{
    public static LanguageSelection instance;

    public List<SupportedLanguage> supportedLanguages;
    public List<Button> languageButtons;
    public List<Button> buttonsToUpdateText;

    private SupportedLanguage selectedLanguage;

    private Dictionary<string, Dictionary<SupportedLanguage, string>> translations;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InitializeTranslations();

        selectedLanguage = SupportedLanguage.English;

        UpdateButtonTexts();

        // Adicione os eventos de clique aos bot�es de idioma
        for (int i = 0; i < languageButtons.Count; i++)
        {
            int index = i; // Armazena o �ndice atual em uma vari�vel tempor�ria
            languageButtons[i].onClick.AddListener(() => SetLanguage(index));
        }
    }

    private void InitializeTranslations()
    {
        translations = new Dictionary<string, Dictionary<SupportedLanguage, string>>();

        // Adicione as tradu��es para cada idioma suportado
        AddTranslation("PLAY", SupportedLanguage.French, "Jouer");
        AddTranslation("PLAY", SupportedLanguage.English, "Play");
        AddTranslation("PLAY", SupportedLanguage.Spanish, "Jugar");
        AddTranslation("PLAY", SupportedLanguage.Portuguese, "Jogar");

        AddTranslation("SETTINGS", SupportedLanguage.French, "Param�tres");
        AddTranslation("SETTINGS", SupportedLanguage.English, "Settings");
        AddTranslation("SETTINGS", SupportedLanguage.Spanish, "Configuraci�n");
        AddTranslation("SETTINGS", SupportedLanguage.Portuguese, "Configura��es");

        AddTranslation("LANGUAGE", SupportedLanguage.French, "Langue");
        AddTranslation("LANGUAGE", SupportedLanguage.English, "Language");
        AddTranslation("LANGUAGE", SupportedLanguage.Spanish, "Idioma");
        AddTranslation("LANGUAGE", SupportedLanguage.Portuguese, "Idioma");

        AddTranslation("CONTROLS", SupportedLanguage.French, "contr�les");
        AddTranslation("CONTROLS", SupportedLanguage.English, "Controls");
        AddTranslation("CONTROLS", SupportedLanguage.Spanish, "Controles");
        AddTranslation("CONTROLS", SupportedLanguage.Portuguese, "Controles");

        AddTranslation("VIDEO", SupportedLanguage.French, "Vid�o");
        AddTranslation("VIDEO", SupportedLanguage.English, "Video");
        AddTranslation("VIDEO", SupportedLanguage.Spanish, "V�deo");
        AddTranslation("VIDEO", SupportedLanguage.Portuguese, "Vid�o");

        AddTranslation("AUDIO", SupportedLanguage.French, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.English, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Spanish, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Portuguese, "�udio");

        AddTranslation("BACK", SupportedLanguage.French, "Retour");
        AddTranslation("BACK", SupportedLanguage.English, "Back");
        AddTranslation("BACK", SupportedLanguage.Spanish, "Volver");
        AddTranslation("BACK", SupportedLanguage.Portuguese, "Voltar");

        AddTranslation("EXIT", SupportedLanguage.French, "Quitter");
        AddTranslation("EXIT", SupportedLanguage.English, "Exit");
        AddTranslation("EXIT", SupportedLanguage.Spanish, "Salir");
        AddTranslation("EXIT", SupportedLanguage.Portuguese, "Sair");

        AddTranslation("SPANISH", SupportedLanguage.French, "Espa�ol");
        AddTranslation("SPANISH", SupportedLanguage.English, "Spanish");
        AddTranslation("SPANISH", SupportedLanguage.Spanish, "Espa�ol");
        AddTranslation("SPANISH", SupportedLanguage.Portuguese, "Espanhol");

        AddTranslation("PORTUGUESE", SupportedLanguage.French, "Portugais");
        AddTranslation("PORTUGUESE", SupportedLanguage.English, "Portuguese");
        AddTranslation("PORTUGUESE", SupportedLanguage.Spanish, "Portugu�s");
        AddTranslation("PORTUGUESE", SupportedLanguage.Portuguese, "Portugu�s");

        AddTranslation("FRENCH", SupportedLanguage.French, "Fran�ais");
        AddTranslation("FRENCH", SupportedLanguage.English, "French");
        AddTranslation("FRENCH", SupportedLanguage.Spanish, "Franc�s");
        AddTranslation("FRENCH", SupportedLanguage.Portuguese, "Franc�s");

        AddTranslation("ENGLISH", SupportedLanguage.French, "Anglais");
        AddTranslation("ENGLISH", SupportedLanguage.English, "English");
        AddTranslation("ENGLISH", SupportedLanguage.Spanish, "Ingl�s");
        AddTranslation("ENGLISH", SupportedLanguage.Portuguese, "Ingl�s");


    }

    private void AddTranslation(string key, SupportedLanguage language, string translation)
    {
        if (!translations.ContainsKey(key))
        {
            translations[key] = new Dictionary<SupportedLanguage, string>();
        }

        translations[key][language] = translation;
    }

    public void SetLanguage(int index)
    {
        selectedLanguage = supportedLanguages[index];
        Debug.Log("Idioma selecionado: " + selectedLanguage.ToString());

        UpdateButtonTexts();
    }

    private void UpdateButtonTexts()
    {
        foreach (Button button in buttonsToUpdateText)
        {
            Text buttonText = button.GetComponentInChildren<Text>();

            if (buttonText != null)
            {
                string translationKey = buttonText.text.ToLower(); // Converter para letras min�sculas

                // Verificar todas as chaves de tradu��o em letras min�sculas
                foreach (var translation in translations)
                {
                    string translationKeyLower = translation.Key.ToLower(); // Converter para letras min�sculas

                    if (translationKeyLower == translationKey)
                    {
                        string translatedText = translation.Value[selectedLanguage];
                        buttonText.text = translatedText;
                        Debug.Log("Texto atualizado para: " + translatedText);
                        break;
                    }
                }
            }
        }
    }
}