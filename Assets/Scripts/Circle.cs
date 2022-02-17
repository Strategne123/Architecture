using UnityEngine;
using DG.Tweening;
using System.Collections;
using Debug = UnityEngine.Debug;

public class Circle : Figure
{
    public override void ChangeSize()
    {
        transform.localScale = new Vector3(Size*20,Size*20,0);
    }

    public override void OnMouseDown()
    {
        if (!ActiveFigure || Blocked) return;
        if (ActiveFigure.Size <= Size)
        {
            ActiveFigure.Blocked = true;
            Blocked = true;
            ActiveFigure.transform.DOMove(transform.position, 1);
            ActiveFigure = null;
        }
        else
        {
            Vector3[] path = {transform.position, ActiveFigure.transform.position};
            ActiveFigure.transform.DOPath(path, 0.9f,PathType.CatmullRom);
            ActiveFigure = null;
        }
        Player.TryChangeValue("Moves",1);
    }
}
