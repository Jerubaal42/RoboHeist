using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonMoveOther))]
[CanEditMultipleObjects]
public class ButtonMoveOtherEditor : Editor
{
    SerializedProperty objectToMove;
    SerializedProperty weighted;
    SerializedProperty weight;
    SerializedProperty distanceToMove;
    SerializedProperty rotationToRotate;
    SerializedProperty fling;
    SerializedProperty flingDirection;
    SerializedProperty flingForce;
    SerializedProperty reusable;
    SerializedProperty toggleOnLeave;
    SerializedProperty active;
    SerializedProperty moved;
    SerializedProperty moveTime;
    
    void OnEnable()
    {
        objectToMove = serializedObject.FindProperty("objectToMove");
        weighted = serializedObject.FindProperty("weighted");
        weight = serializedObject.FindProperty("weight");
        distanceToMove = serializedObject.FindProperty("distanceToMove");
        rotationToRotate = serializedObject.FindProperty("rotationToRotate");
        fling = serializedObject.FindProperty("fling");
        flingDirection = serializedObject.FindProperty("flingDirection");
        flingForce = serializedObject.FindProperty("flingForce");
        reusable = serializedObject.FindProperty("reusable");
        toggleOnLeave = serializedObject.FindProperty("toggleOnLeave");
        active = serializedObject.FindProperty("active");
        moved = serializedObject.FindProperty("moved");
        moveTime = serializedObject.FindProperty("moveTime");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(objectToMove, new GUIContent("Object To Move"));
        EditorGUILayout.PropertyField(weighted, new GUIContent("Weighted Trigger"));
        if (weighted.boolValue)
        {
            EditorGUILayout.PropertyField(weight, new GUIContent("Activation Weight"));
        }
        EditorGUILayout.PropertyField(fling, new GUIContent("Rigidbody Move"));
        if (fling.boolValue)
        {
            EditorGUILayout.PropertyField(flingDirection, new GUIContent("Force Direction"));
            EditorGUILayout.PropertyField(flingForce, new GUIContent("Force Strength"));
            EditorGUILayout.PropertyField(reusable, new GUIContent("Reusable"));
            EditorGUILayout.PropertyField(active, new GUIContent("Used"));
        }
        else
        {
            EditorGUILayout.PropertyField(distanceToMove, new GUIContent("Distance"));
            EditorGUILayout.PropertyField(rotationToRotate, new GUIContent("Rotation"));
            EditorGUILayout.PropertyField(toggleOnLeave, new GUIContent("Reset On Leave"));
            EditorGUILayout.PropertyField(moveTime, new GUIContent("Movement Duration"));
            EditorGUILayout.PropertyField(active, new GUIContent("Enabled"));
            EditorGUILayout.PropertyField(moved, new GUIContent("Movement Finished"));
        }
        serializedObject.ApplyModifiedProperties();
    }
}
