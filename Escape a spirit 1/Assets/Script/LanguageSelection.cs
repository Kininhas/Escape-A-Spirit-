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

        // Adicione os eventos de clique aos botões de idioma
        for (int i = 0; i < languageButtons.Count; i++)
        {
            int index = i; // Armazena o índice atual em uma variável temporária
            languageButtons[i].onClick.AddListener(() => SetLanguage(index));
        }
    }

    private void InitializeTranslations()
    {
        translations = new Dictionary<string, Dictionary<SupportedLanguage, string>>();

        // Adicione as traduções para cada idioma suportado
        AddTranslation("PLAY", SupportedLanguage.French, "Jouer");
        AddTranslation("PLAY", SupportedLanguage.English, "Play");
        AddTranslation("PLAY", SupportedLanguage.Spanish, "Jugar");
        AddTranslation("PLAY", SupportedLanguage.Portuguese, "Jogar");

        AddTranslation("SETTINGS", SupportedLanguage.French, "Paramètres");
        AddTranslation("SETTINGS", SupportedLanguage.English, "Settings");
        AddTranslation("SETTINGS", SupportedLanguage.Spanish, "Configuración");
        AddTranslation("SETTINGS", SupportedLanguage.Portuguese, "Configurações");

        AddTranslation("LANGUAGE", SupportedLanguage.French, "Langue");
        AddTranslation("LANGUAGE", SupportedLanguage.English, "Language");
        AddTranslation("LANGUAGE", SupportedLanguage.Spanish, "Idioma");
        AddTranslation("LANGUAGE", SupportedLanguage.Portuguese, "Idioma");

        AddTranslation("CONTROLS", SupportedLanguage.French, "contrôles");
        AddTranslation("CONTROLS", SupportedLanguage.English, "Controls");
        AddTranslation("CONTROLS", SupportedLanguage.Spanish, "Controles");
        AddTranslation("CONTROLS", SupportedLanguage.Portuguese, "Controles");

        AddTranslation("VIDEO", SupportedLanguage.French, "Vidéo");
        AddTranslation("VIDEO", SupportedLanguage.English, "Video");
        AddTranslation("VIDEO", SupportedLanguage.Spanish, "Vídeo");
        AddTranslation("VIDEO", SupportedLanguage.Portuguese, "Vidéo");

        AddTranslation("AUDIO", SupportedLanguage.French, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.English, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Spanish, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Portuguese, "Áudio");

        AddTranslation("BACK", SupportedLanguage.French, "Retour");
        AddTranslation("BACK", SupportedLanguage.English, "Back");
        AddTranslation("BACK", SupportedLanguage.Spanish, "Volver");
        AddTranslation("BACK", SupportedLanguage.Portuguese, "Voltar");

        AddTranslation("EXIT", SupportedLanguage.French, "Quitter");
        AddTranslation("EXIT", SupportedLanguage.English, "Exit");
        AddTranslation("EXIT", SupportedLanguage.Spanish, "Salir");
        AddTranslation("EXIT", SupportedLanguage.Portuguese, "Sair");

        AddTranslation("SPANISH", SupportedLanguage.French, "Español");
        AddTranslation("SPANISH", SupportedLanguage.English, "Spanish");
        AddTranslation("SPANISH", SupportedLanguage.Spanish, "Español");
        AddTranslation("SPANISH", SupportedLanguage.Portuguese, "Espanhol");

        AddTranslation("PORTUGUESE", SupportedLanguage.French, "Portugais");
        AddTranslation("PORTUGUESE", SupportedLanguage.English, "Portuguese");
        AddTranslation("PORTUGUESE", SupportedLanguage.Spanish, "Portugués");
        AddTranslation("PORTUGUESE", SupportedLanguage.Portuguese, "Português");

        AddTranslation("FRENCH", SupportedLanguage.French, "Français");
        AddTranslation("FRENCH", SupportedLanguage.English, "French");
        AddTranslation("FRENCH", SupportedLanguage.Spanish, "Francés");
        AddTranslation("FRENCH", SupportedLanguage.Portuguese, "Francês");

        AddTranslation("ENGLISH", SupportedLanguage.French, "Anglais");
        AddTranslation("ENGLISH", SupportedLanguage.English, "English");
        AddTranslation("ENGLISH", SupportedLanguage.Spanish, "Inglés");
        AddTranslation("ENGLISH", SupportedLanguage.Portuguese, "Inglês");


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
                string translationKey = buttonText.text.ToLower(); // Converter para letras minúsculas

                // Verificar todas as chaves de tradução em letras minúsculas
                foreach (var translation in translations)
                {
                    string translationKeyLower = translation.Key.ToLower(); // Converter para letras minúsculas

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