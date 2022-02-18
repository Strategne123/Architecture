using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Player
{
    public static Dictionary<string, int> Parameters = new Dictionary<string, int>();
    public delegate void ChangeParameters();
    public static event ChangeParameters ÑhangeParameters;

    public Player()
    {
        Debug.Log("Player");
        if (PlayerPrefs.HasKey("Parameters"))
        {
            var json = PlayerPrefs.GetString("Parameters");
            Parameters=JsonConvert.DeserializeObject<Dictionary<string,int>>(json);
        }
        else
        {
            AddParameter("Moves",0);
            Save();
        }
    }

    public static void AddParameter(string caption,int value)
    {
        Parameters.Add(caption,value);
        ÑhangeParameters?.Invoke();
    }

    public static void TryRemoveParameter(string caption)
    {
        try
        {
            Parameters.Remove(caption);
            ÑhangeParameters?.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void TryChangeValue(string _key, int _magnitude)
    {
        try
        {
            Parameters[_key] += _magnitude;
            ÑhangeParameters?.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Save()
    {
        var json = JsonConvert.SerializeObject(Parameters);
        PlayerPrefs.SetString("Parameters", json);
    }

    public static string GetParameters()
    {
        var str = "";
        foreach (var _parameter in Parameters)
        {
            str += _parameter.Key + ": " + _parameter.Value + " ";
        }
        return str;
    }
}
