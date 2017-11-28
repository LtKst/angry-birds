using UnityEditor;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class ObjectPoolManagerEditor : EditorWindow {

    [MenuItem("Window/Object Pool Manager")]
    public static void ShowWindow() {
        EditorWindow window =  GetWindow(typeof(ObjectPoolManagerEditor));
        window.titleContent = new GUIContent("Object Pools Manager");
    }

    public ObjectPool[] objectPools;

    void OnGUI() {
        EditorGUILayout.LabelField("Object Pools", EditorStyles.boldLabel);

        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty stringsProperty = so.FindProperty("objectPools");

        EditorGUILayout.PropertyField(stringsProperty, true);
        so.ApplyModifiedProperties();
    }
}
