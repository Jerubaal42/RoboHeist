using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonActivateMove))]
[CanEditMultipleObjects]
public class ButtonActivateMoveEditor : Editor
{
    SerializedProperty moveScript;
    SerializedProperty active;
    SerializedProperty toggleOnLeave;
    SerializedProperty weighted;
    SerializedProperty weight;
    SerializedProperty inverted;

    private void OnEnable()
    {
        moveScript = serializedObject.FindProperty("moveScript");
        active = serializedObject.FindProperty("active");
        toggleOnLeave = serializedObject.FindProperty("toggleOnLeave");
        weighted = serializedObject.FindProperty("weighted");
        weight = serializedObject.FindProperty("weight");
        inverted = serializedObject.FindProperty("inverted");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(moveScript, new GUIContent("Object"));
        EditorGUILayout.PropertyField(weighted, new GUIContent("Weighted Trigger"));
        if (weighted.boolValue)
        {
            EditorGUILayout.PropertyField(weight, new GUIContent("Activation Weight"));
        }
        EditorGUILayout.PropertyField(inverted, new GUIContent("Button Stops Spin"));
        EditorGUILayout.PropertyField(toggleOnLeave, new GUIContent("Reset On Leave"));
        EditorGUILayout.PropertyField(active, new GUIContent("Enabled"));
        serializedObject.ApplyModifiedProperties();
    }
}
