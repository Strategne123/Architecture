using UnityEngine;

public class Square : Figure
{
    public override void ChangeSize()
    {
        var newSize = Mathf.Ceil(Size / 1.4142f);
        transform.localScale = new Vector3(newSize, newSize, 0);
    }

    public override void OnMouseDown()
    {
        Debug.Log("Square");
        ActiveFigure = this;
    }
}
