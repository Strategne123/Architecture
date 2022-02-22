using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Figure),true)]
[CanEditMultipleObjects]
public class FigureSize : Editor
{
    public override void OnInspectorGUI()
    {
        var figure = (Figure) target;
        figure.ChangeSize(EditorGUILayout.IntSlider("������ ������", figure.Size, 5, 25));
    }
}
