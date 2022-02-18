using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Figure),true)]
[CanEditMultipleObjects]
public class FigureSize : Editor
{
    public override void OnInspectorGUI()
    {
        var figure = (Figure) target;
        figure.Size = EditorGUILayout.IntSlider("Размер фигуры", figure.Size, 5, 25);
        figure.ChangeSize();
        if (GUILayout.Button("Reset"))
        {
            Debug.Log(1);
        }
    }
}
