using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class ImageSOCreatorTool : EditorWindow
{
    private List<string> imageFilePaths = new List<string>();

    [MenuItem("Tools/Create ContentImageSO")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ImageSOCreatorTool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Create ContentImageSO(s)", EditorStyles.boldLabel);

        Event evt = Event.current;
        Rect dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
        GUI.Box(dropArea, "Drop Image(s) Here");

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
                        if (draggedObject is Texture2D)
                        {
                            string imagePath = AssetDatabase.GetAssetPath(draggedObject);
                            if (!string.IsNullOrEmpty(imagePath))
                            {
                                imageFilePaths.Add(imagePath);
                            }
                        }
                    }

                }
                break;
        }

        GUILayout.Space(60); // Space below drop area

        // Display loaded images
        if (imageFilePaths.Count > 0)
        {
            GUILayout.Label("Images Loaded:", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            int _counter = 0;

            Sprite imageSprite;

            foreach (string sprite in imageFilePaths)
            {
                // Load Image Sprites for preview
                imageSprite = AssetDatabase.LoadAssetAtPath<Sprite>(sprite);
                if (imageSprite == null)
                {
                    Debug.LogError("Image " + sprite + " not found!");
                }

                GUILayout.Label(imageSprite.texture, GUILayout.Width(50), GUILayout.Height(50));
                _counter++;

                if (_counter >= 8)
                {
                    _counter = 0;
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUI.BeginDisabledGroup(imageFilePaths.Count <= 0);
        if (GUILayout.Button("Create ImageSO"))
        {
            CreateCardSOs();

        }

        GUILayout.Space(10); // Space below drop area

        if (GUILayout.Button("Clear Loaded Images"))
        {
            ResetImageList();
        }

        EditorGUI.EndDisabledGroup();

    }

    private void ResetImageList()
    {
        imageFilePaths = new List<string>();
    }

    private void CreateCardSOs()
    {
        foreach (string sprite in imageFilePaths)
        {
            //Get File Name
            string _filename = Path.GetFileNameWithoutExtension(sprite);

            // Create a new CardSO
            ImageContentSO card = CreateInstance<ImageContentSO>();
            card.image = AssetDatabase.LoadAssetAtPath<Sprite>(sprite);
            string[] lines = _filename.Split('_');


            //Order is  Happy, Sad, Bored, Angry
            card.emoteMap = new EmoteScoreDict();
            card.emoteMap[EmoteEnum.Happy] = int.Parse(lines[0]) < 1 ? -3 : int.Parse(lines[0]);
            card.emoteMap[EmoteEnum.Sad] = int.Parse(lines[1]) < 1 ? -3 : int.Parse(lines[1]);
            card.emoteMap[EmoteEnum.Bored] = int.Parse(lines[2]) < 1 ? -3 : int.Parse(lines[2]);
            card.emoteMap[EmoteEnum.Angry] = int.Parse(lines[3]) < 1 ? -3 : int.Parse(lines[3]);

            // Save the CardSO as an asset
            string path = "Assets/Current Content SOs/" + _filename+ "ImageSO.asset";

            
            AssetDatabase.CreateAsset(card, path);
            AssetDatabase.SaveAssets();
            

            Debug.Log("CardSO created: " + path);

        }
        imageFilePaths.Clear(); ;
    }

}
#endif