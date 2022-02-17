using UnityEngine;

public class AddonTriangles: ScriptableObject
{
    private static bool isActive=false;

    public static void Init()
    {
        if (!isActive)
        {
            Debug.Log("Activate");
            isActive = true;
            Player.AddParameter("Energy", 1);
        }
    }

    public static void DeactivateAddon()
    {
        if (isActive)
        {
            Debug.Log("Deactivate");
            isActive = false;
            Player.TryRemoveParameter("Energy");
        }
    }
}
