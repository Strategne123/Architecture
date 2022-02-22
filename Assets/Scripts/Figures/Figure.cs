using System;
using UnityEngine;

[Serializable]
public abstract class Figure : MonoBehaviour
{
    public int Size;
    public bool Blocked;
    public static Figure ActiveFigure;
    public delegate void Click(Figure figure);
    public static event Click click;
    public GameController GameController;

    public abstract void ChangeSize(int newsize);

    protected void ClickFigure(Figure figure)
    {
        click?.Invoke(figure);
    }
}
