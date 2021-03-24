using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class LocalizationEditor : EditorWindow
{
    private LocalizationData localizationData = new LocalizationData();
    [SerializeField]
    private List<LocalizationItem> localizationItem;

    [MenuItem("Window/Localization Editor")]
    private static void ShowWindow()
    {
        GetWindow<LocalizationEditor>("Localization");
    }
    private void OnGUI()
    {
        if (localizationItem != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty
                ("localizationItem");
            EditorGUILayout.PropertyField(serializedProperty);
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Add"))
            {
                AddNewKeyValue();
            }

            GUILayout.Space(15);

            if (GUILayout.Button("Remove"))
            {
                RemoveLastkKeyValue();
            }

            GUILayout.Space(25);

            if (GUILayout.Button("Save"))
            {
                SaveTranslationData();
            }
        }
        if (GUILayout.Button("Load"))
        {
            LoadTranslationData();
        }
        if (GUILayout.Button("Create new"))
        {
            CreateNewTranslationData();
        }

    }
    private void LoadTranslationData()
    {
        string filePath = EditorUtility.OpenFilePanel
            ("Load", Application.streamingAssetsPath, "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            localizationData = JsonUtility.FromJson<LocalizationData>
                (File.ReadAllText(filePath));
            localizationItem = new List<LocalizationItem>();
            localizationItem.AddRange(localizationData.translations);
        }
    }
    private void SaveTranslationData()
    {
        string filePath = EditorUtility.SaveFilePanel
            ("Save", Application.streamingAssetsPath, "", "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            localizationData.translations = localizationItem.ToArray();
            File.WriteAllText(filePath, JsonUtility.ToJson(localizationData));
        }
    }
    private void CreateNewTranslationData()
    {
        localizationItem = new List<LocalizationItem>();
        localizationItem.Add(null);
    }
    private void AddNewKeyValue()
    {
        localizationItem.Add(null);
    }
    private void RemoveLastkKeyValue()
    {
        localizationItem.RemoveAt(localizationItem.Count - 1);
    }
}