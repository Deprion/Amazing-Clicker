using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager inst;
    private string language;
    private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    private void Awake()
    {
        if (inst == null) inst = this;
        else if (inst != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        ChangeLanguage(Application.systemLanguage);
#if UNITY_ANDROID && !UNITY_EDITOR
        StartCoroutine(LoadLocalization());
#endif
#if !UNITY_ANDROID || UNITY_EDITOR
        LoadLocalization();
#endif
    }
    public void ChangeLanguage(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.English:
                language = "Localization_en.json";
                break;
            case SystemLanguage.Russian:
                language = "Localization_ru.json";
                break;
            default:
                language = "Localization_en.json";
                break;
        }
    }
#if UNITY_ANDROID && !UNITY_EDITOR
    private IEnumerator LoadLocalization() 
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, language);
        using (UnityWebRequest www = UnityWebRequest.Get(filePath))
        {
            yield return www.SendWebRequest();
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>
                (www.downloadHandler.text);
            foreach (LocalizationItem item in loadedData)
            {
                localizedText.Add(item.key, item.value);
            }
        }
    }
#endif
#if !UNITY_ANDROID || UNITY_EDITOR
    private void LoadLocalization()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, language);
        if (File.Exists(filePath))
        {
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>
                (File.ReadAllText(filePath));
            foreach (LocalizationItem item in loadedData)
            {
                localizedText.Add(item.key, item.value);
            }
        }
    }
#endif
    public string GetValue(string key)
    {
        try
        {
            if (localizedText.ContainsKey(key))
                return localizedText[key];
        }
        catch (System.ArgumentNullException e) { print(e.Message); };
        return "null";
    }
}
