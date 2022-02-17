using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

[CustomEditor(typeof(GameController), true)]
[CanEditMultipleObjects]
public class GameEditor : Editor
{
    private string _path;
    private string[] _pathes;
    private bool _isInitializate=false;
    private List<object> _addonClasses = new List<object>();
    private Dictionary<string, bool> _addons = new Dictionary<string, bool>();

    private void Init()
    {
        _addons.Clear();
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
                _addons.Add(addonName,false);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void TryActivateAddon(string addonName)
    {
        var addonType = Type.GetType(addonName);
        if (!_addonClasses.Contains(addonType))
        {
            try
            {
                addonType.GetMethod("Init").Invoke(null, null);
                _addonClasses.Add(addonType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    private void TryDeactivateAddon(string addonName)
    {
        var addonType = Type.GetType(addonName);
        if (_addonClasses.Contains(addonType))
        {
            try
            {
                addonType.GetMethod("DeactivateAddon").Invoke(null, null);
                _addonClasses.Remove(addonType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        if (!_isInitializate)
        {
            _isInitializate = true;
            Init();
        }
        for (var i=0;i<_addons.Count;i++)
        {
            var key = _addons.ElementAt(i).Key;
            _addons[key] = EditorGUILayout.Toggle(key, _addons[key]);
            if (_addons[key])
            {
                TryActivateAddon(key);
            }
            else
            {
                TryDeactivateAddon(key);
            }
        }
        if (GUILayout.Button("Refresh"))
        {
            Init();
        }
    }
}