using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
public class CSVToStreamInfoSOTool : EditorWindow
{
    [MenuItem("Tools/CSV to StreamInfoSO Converter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CSVToStreamInfoSOTool), false, "CSV to StreamInfoSO Converter");
    }

    private TextAsset csvFile;
    private List<TwitchInfoSO> messageDataList = new List<TwitchInfoSO>();

    private void OnGUI()
    {
        GUILayout.Label("Select a .csv file:", EditorStyles.boldLabel);
        csvFile = EditorGUILayout.ObjectField(csvFile, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Convert to StreamInfo"))
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

            if (fields.Length >= 3)
            {
                string username = fields[0];
                string streamInfo = fields[1];
                string category = fields[2];

                TwitchInfoSO messageData = ScriptableObject.CreateInstance<TwitchInfoSO>();
                messageData.streamerName = username;
                messageData.streamInfo = streamInfo;
                messageData.category = category;

                string assetPath = "Assets/StreamInfo/" + "StreamContent_"+ i + ".asset";
                AssetDatabase.CreateAsset(messageData, assetPath);

                messageDataList.Add(messageData);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("CSV file converted to ScriptableObjects successfully!");
    }
}
#endif
