using System;
using UnityEngine;

public class Triangle : Figure
{
    public override void ChangeSize(int _size)
    {
        Size = _size;
        transform.localScale = new Vector3(Size * 20, Size * 20, 0);
    }

    public void OnMouseDown()
    {
        Figure.click += FigureDecrease;
    }

    private void FigureDecrease(Figure figure)
    {
        Figure.click -= FigureDecrease;
        if (figure.GetType() == Type.GetType("Square"))
        {
            figure.ChangeSize(figure.Size-1);
            Destroy(this.gameObject);
        }
    }
}
