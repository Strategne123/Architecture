using UnityEngine;
using DG.Tweening;
using System.Collections;
using Debug = UnityEngine.Debug;

public class Circle : Figure
{
    public override void ChangeSize()
    {
        transform.localScale = new Vector3(Size,Size,0);
    }

    public override void OnMouseDown()
    {
        if (!ActiveFigure) return;
        ActiveFigure.transform.DOMove(this.transform.position, 1);
        ActiveFigure = null;
    }
}
