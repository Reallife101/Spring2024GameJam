using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Video;

public class VideoSOContentTool : EditorWindow
{
    private List<string> videoFilePaths = new List<string>();

    [MenuItem("Tools/Create ContentVideoSO")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(VideoSOContentTool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Create ContentVideoSO(s)", EditorStyles.boldLabel);

        Event evt = Event.current;
        Rect dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
        GUI.Box(dropArea, "Drop Video(s) Here");

        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (!dropArea.Contains(evt.mousePosition))
                    break;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (evt.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    foreach (Object draggedObject in DragAndDrop.objectReferences)
                    {
                        if (draggedObject is VideoClip)
                        {
                            string videoPath = AssetDatabase.GetAssetPath(draggedObject);
                            if (!string.IsNullOrEmpty(videoPath))
                            {
                                videoFilePaths.Add(videoPath);
                            }
                        }
                    }

                }
                break;
        }

        GUILayout.Space(60); // Space below drop area
        GUILayout.Label("Loaded Videos:"+ videoFilePaths.Count, EditorStyles.boldLabel);


        EditorGUI.BeginDisabledGroup(videoFilePaths.Count <= 0);
        if (GUILayout.Button("Create VideoSO"))
        {
            CreateCardSOs();

        }

        GUILayout.Space(10); // Space below drop area

        if (GUILayout.Button("Clear Loaded Videos"))
        {
            ResetImageList();
        }

        EditorGUI.EndDisabledGroup();

    }

    private void ResetImageList()
    {
        videoFilePaths = new List<string>();
    }

    private void CreateCardSOs()
    {
        foreach (string sprite in videoFilePaths)
        {
            //Get File Name
            string _filename = Path.GetFileNameWithoutExtension(sprite);

            // Create a new CardSO
            VideoContentSO card = CreateInstance<VideoContentSO>();
            card.clip = AssetDatabase.LoadAssetAtPath<VideoClip>(sprite);
            string[] lines = _filename.Split('_');


            //Order is  Happy, Sad, Bored, Angry
            card.emoteMap = new EmoteScoreDict();
            card.emoteMap[EmoteEnum.Happy] = int.Parse(lines[0])-1;
            card.emoteMap[EmoteEnum.Sad] = int.Parse(lines[1])-1;
            card.emoteMap[EmoteEnum.Bored] = int.Parse(lines[2])-1;
            card.emoteMap[EmoteEnum.Angry] = int.Parse(lines[3])-1;

            // Save the CardSO as an asset
            string path = "Assets/Current Content SOs/" + _filename + "ImageSO.asset";


            AssetDatabase.CreateAsset(card, path);
            AssetDatabase.SaveAssets();


            Debug.Log("CardSO created: " + path);

        }
        videoFilePaths.Clear(); ;
    }
}
