using UnityEngine;

public abstract class Addon: ScriptableObject
{
    protected bool isActive;
    public abstract void Init();
    public abstract void DeactivateAddon();
}