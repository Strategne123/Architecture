using UnityEngine;

public class Square : Figure
{
    public override void ChangeSize()
    {
        var newSize = Mathf.Ceil(Size * 20 / Mathf.Sqrt(2));
        transform.localScale = new Vector3(newSize, newSize, 0);
    }

    public override void OnMouseDown()
    {
        if (Blocked) return;
        print("Square");
        ActiveFigure = this;
        ClickFigure(this);
    }
}
