using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Figure),true)]
[CanEditMultipleObjects]
public class FigureSize : Editor
{
    public override void OnInspectorGUI()
    {
        
        var figure = (Figure) target;
        figure.Size = EditorGUILayout.IntSlider("Размер фигуры", figure.Size, 200, 600);
        figure.ChangeSize();
    }
}
