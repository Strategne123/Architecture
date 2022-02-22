using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Figures", menuName = "Configs/Figures", order = 0)]
public class FigureController : ScriptableObject,ICloneable
{
    public GameObject[] Figures;

    private FigureController(GameObject[] figures)
    {
        Figures = figures;
    }

    public object Clone()
    {
        return new FigureController(Figures);
    }
}
