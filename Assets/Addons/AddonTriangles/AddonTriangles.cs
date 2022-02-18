using UnityEngine;

public class AddonTriangles
{
    private static bool isActive=false;

    public void Init()
    {
        if (!isActive)
        {
            Debug.Log("Activate");
            isActive = true;
            Player.AddParameter("Energy", 1);
            
        }
    }

    public void DeactivateAddon()
    {
        if (isActive)
        {
            Debug.Log("Deactivate");
            isActive = false;
            Player.TryRemoveParameter("Energy");
        }
    }
}
