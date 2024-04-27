using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class CSVtoMessageSOTool : EditorWindow
{
    [MenuItem("Tools/CSV to ScriptableObject Converter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CSVtoMessageSOTool), false, "CSV to ScriptableObject Converter");
    }

    private TextAsset csvFile;
    private List<MessageSO> messageDataList = new List<MessageSO>();

    private void OnGUI()
    {
        GUILayout.Label("Select a .csv file:", EditorStyles.boldLabel);
        csvFile = EditorGUILayout.ObjectField(csvFile, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Convert"))
        {
            ConvertCSVToScriptableObjects();
        }
    }

    private void ConvertCSVToScriptableObjects()
    {
        if (csvFile == null)
        {
            Debug.LogError("No .csv file selected!");
            return;
        }

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // Start from index 1 to skip the header
        {
            string[] fields = lines[i].Split(',');

            if (fields.Length >= 2)
            {
                string username = fields[0];
                string content = fields[1];

                MessageSO messageData = ScriptableObject.CreateInstance<MessageSO>();
                messageData.senderName = username;
                messageData.content = content;

                string assetPath = "Assets/Messages/" + username + "_" + i + ".asset";
                AssetDatabase.CreateAsset(messageData, assetPath);

                messageDataList.Add(messageData);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("CSV file converted to ScriptableObjects successfully!");
    }
}
