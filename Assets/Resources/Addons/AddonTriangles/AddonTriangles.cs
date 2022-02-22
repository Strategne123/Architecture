using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddonTriangles", menuName = "Addons/Triangles", order = 0)]
public class AddonTriangles : Addon
{
    public GameObject Triangle;

    public override void Init(GameController gameController)
    {
        if (!gameController.Figures.Contains(Triangle))
        {
            gameController.Figures.Add(Triangle);
        }
    }

    public override void InitParameter(GameController gameController)
    {
        gameController.AddParameter(FeatureCaption, FeatureValue);
    }

    public override void Deactivate(GameController gameController)
    {
        if (gameController.Figures.Contains(Triangle))
        {
            gameController.Figures.Remove(Triangle);
        }
    }
}
