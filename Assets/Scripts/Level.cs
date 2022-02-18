using UnityEngine;
using System.Collections.Generic;

public class Level:ScriptableObject
{
    public Dictionary<string, bool> Addons;
    public string Caption;

    public Level(string caption)
    {
        Caption = caption;
        Addons = new Dictionary<string, bool>();
    }
}
