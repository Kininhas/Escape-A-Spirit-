using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SupportedLanguage
{
    French,
    English,
    Spanish,
    Portuguese,
    Korean
}

public class LanguageSelection : MonoBehaviour
{
    public static LanguageSelection instance;

    public List<SupportedLanguage> supportedLanguages;
    public List<Button> languageButtons;
    public List<Button> buttonsToUpdateText;
    public GameObject languageConfirmationCanvas;
    public string translationKey;

    private Button button;
    private Text buttonText;
    private SupportedLanguage selectedLanguage;

    private Dictionary<string, Dictionary<SupportedLanguage, string>> translations;
    private const string LanguageIndexKey = "SelectedLanguageIndex";

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

        // Recupera o índice do idioma selecionado do PlayerPrefs (se existir)
        int savedLanguageIndex = PlayerPrefs.GetInt(LanguageIndexKey, -1);
        if (savedLanguageIndex >= 0 && savedLanguageIndex < supportedLanguages.Count)
        {
            selectedLanguage = supportedLanguages[savedLanguageIndex];
        }
        else
        {
            selectedLanguage = SupportedLanguage.English;
        }

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
        AddTranslation("PLAY", SupportedLanguage.Korean, "재생");

        AddTranslation("SETTINGS", SupportedLanguage.French, "Paramètres");
        AddTranslation("SETTINGS", SupportedLanguage.English, "Settings");
        AddTranslation("SETTINGS", SupportedLanguage.Spanish, "Configuración");
        AddTranslation("SETTINGS", SupportedLanguage.Portuguese, "Configurações");
        AddTranslation("SETTINGS", SupportedLanguage.Korean, "설정");

        AddTranslation("LANGUAGE", SupportedLanguage.French, "Langue");
        AddTranslation("LANGUAGE", SupportedLanguage.English, "Language");
        AddTranslation("LANGUAGE", SupportedLanguage.Spanish, "Idioma");
        AddTranslation("LANGUAGE", SupportedLanguage.Portuguese, "Idioma");
        AddTranslation("LANGUAGE", SupportedLanguage.Korean, "언어");

        AddTranslation("CONTROLS", SupportedLanguage.French, "contrôles");
        AddTranslation("CONTROLS", SupportedLanguage.English, "Controls");
        AddTranslation("CONTROLS", SupportedLanguage.Spanish, "Controles");
        AddTranslation("CONTROLS", SupportedLanguage.Portuguese, "Controles");
        AddTranslation("CONTROLS", SupportedLanguage.Korean, "제어");

        AddTranslation("VIDEO", SupportedLanguage.French, "Vidéo");
        AddTranslation("VIDEO", SupportedLanguage.English, "Video");
        AddTranslation("VIDEO", SupportedLanguage.Spanish, "Vídeo");
        AddTranslation("VIDEO", SupportedLanguage.Portuguese, "Vídeo");
        AddTranslation("VIDEO", SupportedLanguage.Korean, "비디오");

        AddTranslation("AUDIO", SupportedLanguage.French, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.English, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Spanish, "Audio");
        AddTranslation("AUDIO", SupportedLanguage.Portuguese, "Áudio");
        AddTranslation("AUDIO", SupportedLanguage.Korean, "오디오");

        AddTranslation("BACK", SupportedLanguage.French, "Retour");
        AddTranslation("BACK", SupportedLanguage.English, "Back");
        AddTranslation("BACK", SupportedLanguage.Spanish, "Volver");
        AddTranslation("BACK", SupportedLanguage.Portuguese, "Voltar");
        AddTranslation("BACK", SupportedLanguage.Korean, "뒤로");

        AddTranslation("EXIT", SupportedLanguage.French, "Quitter");
        AddTranslation("EXIT", SupportedLanguage.English, "Exit");
        AddTranslation("EXIT", SupportedLanguage.Spanish, "Salir");
        AddTranslation("EXIT", SupportedLanguage.Portuguese, "Sair");
        AddTranslation("EXIT", SupportedLanguage.Korean, "종료");

        AddTranslation("SPANISH", SupportedLanguage.French, "Espagnol");
        AddTranslation("SPANISH", SupportedLanguage.English, "Spanish");
        AddTranslation("SPANISH", SupportedLanguage.Spanish, "Español");
        AddTranslation("SPANISH", SupportedLanguage.Portuguese, "Espanhol");
        AddTranslation("SPANISH", SupportedLanguage.Korean, "Spanish");

        AddTranslation("PORTUGUESE", SupportedLanguage.French, "Portugais");
        AddTranslation("PORTUGUESE", SupportedLanguage.English, "Portuguese");
        AddTranslation("PORTUGUESE", SupportedLanguage.Spanish, "Portugués");
        AddTranslation("PORTUGUESE", SupportedLanguage.Portuguese, "Português");
        AddTranslation("PORTUGUESE", SupportedLanguage.Korean, "Portuguese");

        AddTranslation("FRENCH", SupportedLanguage.French, "Français");
        AddTranslation("FRENCH", SupportedLanguage.English, "French");
        AddTranslation("FRENCH", SupportedLanguage.Spanish, "Francés");
        AddTranslation("FRENCH", SupportedLanguage.Portuguese, "Francês");
        AddTranslation("FRENCH", SupportedLanguage.Korean, "French");

        AddTranslation("ENGLISH", SupportedLanguage.French, "Anglais");
        AddTranslation("ENGLISH", SupportedLanguage.English, "English");
        AddTranslation("ENGLISH", SupportedLanguage.Spanish, "Inglés");
        AddTranslation("ENGLISH", SupportedLanguage.Portuguese, "Inglês");
        AddTranslation("ENGLISH", SupportedLanguage.Korean, "English");

        AddTranslation("KOREAN", SupportedLanguage.French, "Coréen");
        AddTranslation("KOREAN", SupportedLanguage.English, "Korean");
        AddTranslation("KOREAN", SupportedLanguage.Spanish, "Coreano");
        AddTranslation("KOREAN", SupportedLanguage.Portuguese, "Coreano");
        AddTranslation("KOREAN", SupportedLanguage.Korean, "Korean");
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

        // Salva o índice do idioma selecionado no PlayerPrefs
        PlayerPrefs.SetInt(LanguageIndexKey, index);
        PlayerPrefs.Save();

        // Exibe a mensagem de confirmação
        languageConfirmationCanvas.GetComponent<LanguageConfirmation>().ShowConfirmation(selectedLanguage);

        UpdateButtonTexts();

        // Dispara o evento de mudança de idioma
        OnLanguageChange?.Invoke();
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

    public string GetTranslation(string key)
    {
        if (translations.ContainsKey(key))
        {
            return translations[key][selectedLanguage];
        }
        else
        {
            Debug.LogWarning("Chave de tradução não encontrada: " + key);
            return string.Empty;
        }
    }

    // Evento de mudança de idioma
    public event Action OnLanguageChange;
}
