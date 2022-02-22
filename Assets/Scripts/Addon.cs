using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Addon:ScriptableObject
{
    public string Caption;
    public bool isActive;
    public string FeatureCaption;
    public int FeatureValue;
    public int minFeatureValue = 1;
    public int maxFeatureValue = 5;

    public abstract void Init(GameController gameController);

    public abstract void InitParameter(GameController gameController);

    public abstract void Deactivate(GameController gameController);

}