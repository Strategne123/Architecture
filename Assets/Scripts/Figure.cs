using System;
using UnityEngine;

[Serializable]
public abstract class Figure : MonoBehaviour
{
    public int Size;
    public static Figure ActiveFigure;
    public abstract void ChangeSize();
    public abstract void OnMouseDown();
}
