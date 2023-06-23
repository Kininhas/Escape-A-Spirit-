using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
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
    public Dropdown languageDropdown;
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

        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(new List<string> { "Français", "English", "Español", "Português" });

        selectedLanguage = SupportedLanguage.English;

        UpdateButtonTexts();
    }

    private void InitializeTranslations()
    {
        translations = new Dictionary<string, Dictionary<SupportedLanguage, string>>();

        // Adicione as traduções para cada idioma suportado
        AddTranslation("Play", SupportedLanguage.French, "Jouer");
        AddTranslation("Play", SupportedLanguage.English, "Play");
        AddTranslation("Play", SupportedLanguage.Spanish, "Jugar");
        AddTranslation("Play", SupportedLanguage.Portuguese, "Jogar");

        AddTranslation("Settings", SupportedLanguage.French, "Paramètres");
        AddTranslation("Settings", SupportedLanguage.English, "Settings");
        AddTranslation("Settings", SupportedLanguage.Spanish, "Configuración");
        AddTranslation("Settings", SupportedLanguage.Portuguese, "Configurações");

        AddTranslation("Language", SupportedLanguage.French, "Langue");
        AddTranslation("Language", SupportedLanguage.English, "Language");
        AddTranslation("Language", SupportedLanguage.Spanish, "Idioma");
        AddTranslation("Language", SupportedLanguage.Portuguese, "Idioma");
        
        AddTranslation("Controls", SupportedLanguage.French, "Contôles");
        AddTranslation("Controls", SupportedLanguage.English, "Controls");
        AddTranslation("Controls", SupportedLanguage.Spanish, "Controles");
        AddTranslation("Controls", SupportedLanguage.Portuguese, "Controles");
        
        AddTranslation("Video", SupportedLanguage.French, "Vidéo");
        AddTranslation("Video", SupportedLanguage.English, "Video");
        AddTranslation("Video", SupportedLanguage.Spanish, "Vídeo");
        AddTranslation("Video", SupportedLanguage.Portuguese, "Vidéo");

        AddTranslation("Audio", SupportedLanguage.French, "Audio");
        AddTranslation("Audio", SupportedLanguage.English, "Audio");
        AddTranslation("Audio", SupportedLanguage.Spanish, "Audio");
        AddTranslation("Audio", SupportedLanguage.Portuguese, "Áudio");
        
        AddTranslation("Back", SupportedLanguage.French, "Retour");
        AddTranslation("Back", SupportedLanguage.English, "Back");
        AddTranslation("Back", SupportedLanguage.Spanish, "Volver");
        AddTranslation("Back", SupportedLanguage.Spanish, "Voltar");

        AddTranslation("Exit", SupportedLanguage.French, "Quitter");
        AddTranslation("Exit", SupportedLanguage.English, "Exit");
        AddTranslation("Exit", SupportedLanguage.Spanish, "Salir");
        AddTranslation("Exit", SupportedLanguage.Portuguese, "Sair");
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
                string translationKey = buttonText.text;

                if (translations.ContainsKey(translationKey))
                {
                    string translatedText = translations[translationKey][selectedLanguage];
                    buttonText.text = translatedText;
                }
                else
                {
                    Debug.LogWarning("Tradução não encontrada para a chave: " + translationKey);
                }
            }
        }
    }
}
