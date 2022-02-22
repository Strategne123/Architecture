using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using Unity.VisualScripting;

[System.Serializable]
[CreateAssetMenu(fileName = "Lvl", menuName = "Configs/Lvl", order = 2)]
public class Level:ScriptableObject
{
    public List<Addon> Addons=new List<Addon>();

    public void Init(List<Addon> addons)
    {
        Debug.Log("Init");
        /*foreach (var addon in addons.Where(addon => !isIn(Addons, addon)))
        {
            Addons.Add(addon);
        }
        for(var i=0; i<Addons.Count;i++)
        {
            if (!isIn(addons,Addons[i]))
            {
                Addons.Remove(Addons[i]);
            }
        }*/
        Addons = addons;
    }

    /*private bool isIn(List<Addon> lAddons, Addon addon)
    {
        var addon2 = new Addon(addon.Caption, !addon.isActive,);
        if (lAddons.Contains(addon) || lAddons.Contains(addon2))
        {
            return true;
        }
        return false;
    }*/
}

