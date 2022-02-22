using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "Levels", menuName = "Configs/Levels", order = 1)]
public class LevelsController : ScriptableObject
{
    [Serializable]
    public struct Lvls
    {
        public string CaptionLvl;
    }

    public List<Lvls> Levels = new List<Lvls>();

}
