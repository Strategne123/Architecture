using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Levels", menuName = "Configs/Levels", order = 1)]
public class LevelsController : ScriptableObject
{
    public Dictionary<string, Dictionary<string, bool>> Levels=new Dictionary<string, Dictionary<string, bool>>();
}
