using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
using UnityEditorInternal;

class ApplyOrderTag : EditorWindow
{


    int tagNum = 0;
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    private int layer = 0;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Topville/Order Layer Tag")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(ApplyOrderTag));
    }

    void OnGUI()
    {
        var internalEditorUtilityType = typeof(InternalEditorUtility);

        var tags = (string[])UnityEditorInternal.InternalEditorUtility.tags;
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        tagNum = EditorGUILayout.Popup("Tag", tagNum, tags);
        var obj = GameObject.FindGameObjectsWithTag(tags[tagNum]);

        var sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        var sortingLayers = (string[])sortingLayersProperty.GetValue(null, new object[0]);

        layer = EditorGUILayout.Popup("Layer", layer, sortingLayers);

        if (GUILayout.Button("Apply"))
        {
            foreach (var gameObject in obj)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayers[layer];
            }
        }
        //EditorGUILayout.EndToggleGroup();
    }
}