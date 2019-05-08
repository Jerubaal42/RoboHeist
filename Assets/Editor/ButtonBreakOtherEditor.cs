using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonBreakOther))]
[CanEditMultipleObjects]
public class ButtonBreakOtherEditor : Editor
{
    SerializedProperty explode;
    SerializedProperty weighted;
    SerializedProperty weight;
    SerializedProperty breakObject;
    SerializedProperty explodeSpeed;
    SerializedProperty changeCamera;

    void OnEnable()
    {
        explode = serializedObject.FindProperty("explode");
        weighted = serializedObject.FindProperty("weighted");
        weight = serializedObject.FindProperty("weight");
        breakObject = serializedObject.FindProperty("breakObject");
        explodeSpeed = serializedObject.FindProperty("explodeSpeed");
        changeCamera = serializedObject.FindProperty("changeCamera");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(breakObject, new GUIContent("Object To Break"));
        EditorGUILayout.PropertyField(explode, new GUIContent("Explosive"));
        if (explode.boolValue)
        {
            EditorGUILayout.PropertyField(explodeSpeed, new GUIContent("Explode Speed"));
        }
        EditorGUILayout.PropertyField(weighted, new GUIContent("Weighted Trigger"));
        if (weighted.boolValue)
        {
            EditorGUILayout.PropertyField(weight, new GUIContent("Activation Weight"));
        }
        EditorGUILayout.PropertyField(changeCamera, new GUIContent("Result Camera"));
        serializedObject.ApplyModifiedProperties();
    }
}
