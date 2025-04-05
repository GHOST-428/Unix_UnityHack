using MelonLoader;
using UnityEngine;
using static UNIX_Log.Logger;
using Il2Cpp;

public class InspectorUnity : MelonMod
{
    private static GameObject hoveredObject;

    public static GameObject GetInspect_GameObject()
    {
        hoveredObject = RaycastObject();
        return hoveredObject;
    }

    private static GameObject RaycastObject()
    {
        // Raycast from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Return the object that was hit
            return hit.transform.gameObject;
        }

        return null;
    }
}