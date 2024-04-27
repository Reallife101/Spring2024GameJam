using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(message))]
public class MessageTestTool : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        message m = (message)target;

        if (GUILayout.Button("Get Num Lines"))
        {
            Debug.Log(m.GetNumLines());
        }

        if (GUILayout.Button("Initialize"))
        {
            m.InitializeMessage();
        }
    }
}
