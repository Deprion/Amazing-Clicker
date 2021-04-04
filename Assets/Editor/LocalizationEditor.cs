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

            if (GUILayout.Button("Add", GUILayout.MinHeight(30)))
            {
                AddNewKeyValue();
            }

            if (GUILayout.Button("Remove", GUILayout.MinHeight(30)))
            {
                RemoveLastkKeyValue();
            }

            if (GUILayout.Button("Save", GUILayout.MinHeight(30)))
            {
                SaveTranslationData();
            }
        }
        if (GUILayout.Button("Load", GUILayout.MinHeight(30)))
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