using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Escalator))]
[CanEditMultipleObjects]
public class EscalatorEditor : Editor
{
    SerializedProperty step;
    SerializedProperty firstStep;
    SerializedProperty secondStep;
    SerializedProperty thirdStep;
    SerializedProperty fourthStep;
    SerializedProperty speed;
    SerializedProperty stepNumber;
    SerializedProperty active;

    private void OnEnable()
    {
        step = serializedObject.FindProperty("step");
        firstStep = serializedObject.FindProperty("firstStep");
        secondStep = serializedObject.FindProperty("secondStep");
        thirdStep = serializedObject.FindProperty("thirdStep");
        fourthStep = serializedObject.FindProperty("fourthStep");
        speed = serializedObject.FindProperty("speed");
        stepNumber = serializedObject.FindProperty("stepNumber");
        active = serializedObject.FindProperty("active");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(step, new GUIContent("Step Object"));
        EditorGUILayout.PropertyField(stepNumber, new GUIContent("Number of Steps"));
        EditorGUILayout.PropertyField(firstStep, new GUIContent("First Corner"));
        EditorGUILayout.PropertyField(secondStep, new GUIContent("Second Corner"));
        EditorGUILayout.PropertyField(thirdStep, new GUIContent("Third Corner"));
        EditorGUILayout.PropertyField(fourthStep, new GUIContent("Fourth Corner"));
        EditorGUILayout.PropertyField(speed, new GUIContent("Escalator Speed"));
        EditorGUILayout.PropertyField(active, new GUIContent("Active"));
        serializedObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        Escalator e = (Escalator)target;
        EditorGUI.BeginChangeCheck();
        Vector3 aStep = Handles.PositionHandle(e.firstStep, Quaternion.identity);
        Vector3 bStep = Handles.PositionHandle(e.secondStep, Quaternion.identity);
        Vector3 cStep = Handles.PositionHandle(e.thirdStep, Quaternion.identity);
        Vector3 dStep = Handles.PositionHandle(e.fourthStep, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(e, "Change Escalator Step");
            e.firstStep = aStep;
            e.secondStep = bStep;
            e.thirdStep = cStep;
            e.fourthStep = dStep;
        }
    }
}
