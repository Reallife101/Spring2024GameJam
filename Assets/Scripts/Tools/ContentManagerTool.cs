using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(ContentManager))]
public class ContentManagerTool : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ContentManager m = (ContentManager)target;

        if (GUILayout.Button("Get New Content"))
        {
            m.chooseNewContent();
        }

    }
}
#endif
