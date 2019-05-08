using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonActivateSpin))]
[CanEditMultipleObjects]
public class ButtonActivateSpinEditor : Editor
{
    SerializedProperty spinScript;
    SerializedProperty active;
    SerializedProperty toggleOnLeave;
    SerializedProperty weighted;
    SerializedProperty weight;
    SerializedProperty inverted;
    SerializedProperty changeCamera;

    private void OnEnable()
    {
        spinScript = serializedObject.FindProperty("spinScript");
        active = serializedObject.FindProperty("active");
        toggleOnLeave = serializedObject.FindProperty("toggleOnLeave");
        weighted = serializedObject.FindProperty("weighted");
        weight = serializedObject.FindProperty("weight");
        inverted = serializedObject.FindProperty("inverted");
        changeCamera = serializedObject.FindProperty("changeCamera");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(spinScript, new GUIContent("Object"));
        EditorGUILayout.PropertyField(weighted, new GUIContent("Weighted Trigger"));
        if (weighted.boolValue)
        {
            EditorGUILayout.PropertyField(weight, new GUIContent("Activation Weight"));
        }
        EditorGUILayout.PropertyField(inverted, new GUIContent("Button Stops Spin"));
        EditorGUILayout.PropertyField(toggleOnLeave, new GUIContent("Reset On Leave"));
        EditorGUILayout.PropertyField(active, new GUIContent("Enabled"));
        EditorGUILayout.PropertyField(changeCamera, new GUIContent("Result Camera"));
        serializedObject.ApplyModifiedProperties();
    }
}
