using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ZoneManager))]
public class CameraEditor : Editor
{
    CameraZone lastZone;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ZoneManager zone = (ZoneManager)target;
        if (zone.zones.Count > 0)
            lastZone = zone.zones[zone.zones.Count - 1];

        if (GUILayout.Button("Create new zone"))
        {
            GameObject newZone = zone.CreateZone();
            if (zone.zones.Count > 1)
            {
                Vector2 newPos = new Vector2(lastZone.col.bounds.max.x + newZone.transform.localScale.x/2f, lastZone.transform.position.y);
                newZone.transform.position = newPos;
            }
            Selection.activeGameObject = newZone; //Select the new Zone in hierarchy
        }

        if (zone.zones.Count > 0)
        {
            for (int i = 0; i < zone.zones.Count; i++)
            {
                if (zone.zones[i] == null)
                    zone.zones.RemoveAt(i);
            }
        }
    }
}
