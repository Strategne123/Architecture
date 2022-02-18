using System;
using UnityEngine;

[Serializable]
public abstract class Figure : MonoBehaviour
{
    public int Size;
    public bool Blocked;
    public static Figure ActiveFigure;
    public abstract void ChangeSize();
    public abstract void OnMouseDown();
    public delegate void Click(Figure figure);
    public static event Click click;

    protected void ClickFigure(Figure figure)
    {
        click?.Invoke(figure);
    }
}
