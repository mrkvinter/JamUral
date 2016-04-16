using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
using UnityEditorInternal;

class ApplyOrderLayer : EditorWindow
{
    

    string nameGO = "Object name";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    private int layer = 0;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Topville/Order Layer")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(ApplyOrderLayer));
    }

    void OnGUI()
    {
        
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        nameGO = EditorGUILayout.TextField("Text Field", nameGO);
        var obj = GameObject.Find(nameGO);

        var internalEditorUtilityType = typeof(InternalEditorUtility);
        var sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        var sortingLayers = (string[])sortingLayersProperty.GetValue(null, new object[0]);

        layer = EditorGUILayout.Popup("Layer", layer, sortingLayers);

        if (GUILayout.Button("Apply"))
        {
            for (var i = 0; i < obj.transform.childCount; i++)
            {
                var c = obj.transform.GetChild(i);
                c.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayers[layer];
            }
        }
        //EditorGUILayout.EndToggleGroup();
    }
}
