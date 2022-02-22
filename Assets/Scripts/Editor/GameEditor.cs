using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(GameController))]
[CanEditMultipleObjects]
public class GameEditor : Editor
{
    private GameController gameController;
    private List<object> _addonClasses = new List<object>();
    private bool isInitialize=false;

    private void Init()
    {
        UnityEngine.Object[] selection = Selection.GetFiltered(typeof(GameController), SelectionMode.Assets);
        if (selection.Length > 0)
        {
            if (selection[0] == null)
                return;
            gameController = (GameController) selection[0];
            var addons = new List<Addon>();
            gameController.Addons = Resources.FindObjectsOfTypeAll<Addon>().ToList();
        }
    }

    private void ActivateAddon(Addon addon)
    {
        if (!_addonClasses.Contains(addon))
        {
            addon.Init(gameController);
            _addonClasses.Add(addon);
        }
    }

    private void DeactivateAddon(Addon addon)
    {
        if (_addonClasses.Contains(addon))
        {
            addon.Deactivate(gameController);
            _addonClasses.Remove(addon);
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (!isInitialize)
        {
            Init();
            isInitialize = true;
        }
        serializedObject.Update();
        var gameController = (GameController) target;
        var addons = gameController.Addons;
        if (GUILayout.Button("Refresh Addons"))
        {
            Init();
        }
        for (var i=0;i<addons.Count;i++)
        {
            GUILayout.BeginVertical();
            addons[i].isActive = EditorGUILayout.Toggle(addons[i].Caption, addons[i].isActive);
            if (addons[i].isActive)
            {
                ActivateAddon(addons[i]);
                addons[i].FeatureValue = EditorGUILayout.IntSlider(addons[i].FeatureCaption, addons[i].FeatureValue, addons[i].minFeatureValue, addons[i].maxFeatureValue);
            }
            else
            {
                DeactivateAddon(addons[i]);
            }
            GUILayout.EndVertical();
        }
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        foreach (var figure in gameController.Figures)
        {
            if (GUILayout.Button(figure.name))
            {
                gameController.AddFigure(figure);
            }
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("AddScene"))
        {
            gameController.AddScene();
        }
        EditorUtility.SetDirty(gameController);
        serializedObject.ApplyModifiedProperties();
    }
}