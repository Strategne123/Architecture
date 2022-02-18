using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(GameController), true)]
[CanEditMultipleObjects]
public class GameEditor : Editor
{
    private string _path;
    private string[] _pathes;
    private bool _isInitializate=false;
    private List<object> _addonClasses = new List<object>();
   
    private void Init()
    {
        var gameController = (GameController)target;
        var level = gameController.LevelsController.Levels[SceneManager.GetActiveScene().name];
        level.Clear();
        try
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _path = path.Combine(Application.persistentDataPath + "/Addons/");
#else
            _path = Path.Combine(Application.dataPath + "/Addons/");
#endif
            _pathes = Directory.GetDirectories(_path, "*", SearchOption.TopDirectoryOnly);
            foreach (var path in _pathes)
            {
                var addonName = path.Split('/').Last();
                level.Add(addonName,false);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static Type FindType(string qualifiedTypeName)
    {
        Type t = Type.GetType(qualifiedTypeName);

        if (t != null)
        {
            return t;
        }
        else
        {
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                t = asm.GetType(qualifiedTypeName);
                if (t != null)
                    return t;
            }
            return null;
        }
    }

    private void TryActivateAddon(string addonName)
    {
        var addonType = FindType(addonName);
        try
        {
            if (!_addonClasses.Contains(addonType))
            {
                var addonClass = Activator.CreateInstance(addonType);
                addonType.GetMethod("Init").Invoke(addonClass, null);
                _addonClasses.Add(addonClass);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void TryDeactivateAddon(string addonName)
    {
        var addonType = FindType(addonName);
        foreach (var addonClass in _addonClasses)
        {
            if (addonClass.GetType() == addonType)
            {
                addonType.GetMethod("DeactivateAddon").Invoke(addonClass, null);
                _addonClasses.Remove(addonClass);
                return;
            }
        }
        Console.WriteLine("Не удалось деактивировать аддон");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        if (!_isInitializate)
        {
            _isInitializate = true;
            Init();
        }
        var gameController = (GameController)target;
        var level = gameController.LevelsController.Levels.First().Value;
        if (GUILayout.Button("Refresh"))
        {
            Init();
        }
        for (var i=0;i< level.Count;i++)
        {
            var key = level.ElementAt(i).Key;
            level[key] = EditorGUILayout.Toggle(key, level[key]);
            if (level[key])
            {
                TryActivateAddon(key);
            }
            else
            {
                TryDeactivateAddon(key);
            }
        }
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        foreach (var figure in gameController.FigureController.Figures)
        {
            if (GUILayout.Button(figure.name))
            {
                gameController.AddFigure(figure);
            }
        }
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}