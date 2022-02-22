using UnityEngine;

public class Square : Figure
{
    public override void ChangeSize(int _size)
    {
        Size = _size;
        var newSize = Mathf.Ceil(Size * 20 / Mathf.Sqrt(2));
        transform.localScale = new Vector3(newSize, newSize, 0);
    }

    public void OnMouseDown()
    {
        if (Blocked) return;
        ActiveFigure = this;
        ClickFigure(this);
    }
}
