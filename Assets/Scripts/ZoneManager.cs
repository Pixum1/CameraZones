using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public List<CameraZone> zones;
    [SerializeField]
    private Vector2 defaultSize = new Vector2(40,22.5f);
    [SerializeField]
    private float defaultCamSize = 11.25f;

    [SerializeField]
    public LayerMask playerLayer;
    /// <summary>
    /// Creates a new CameraZone and returns it.
    /// </summary>
    /// <returns>Instance of CameraZone</returns>
    public GameObject CreateZone() {
        GameObject zone = new GameObject("CameraZone");
        zone.transform.SetParent(transform);
        zone.transform.localScale = defaultSize;
        zone.AddComponent<CameraZone>().playerLayer = playerLayer;
        zone.AddComponent<BoxCollider>().isTrigger = true;
        zones.Add(zone.GetComponent<CameraZone>());
        zone.GetComponent<CameraZone>().col = zone.GetComponent<BoxCollider>();
        zone.GetComponent<CameraZone>().zoneManager = this;
        zone.GetComponent<CameraZone>().cameraOrthographicSize = defaultCamSize;
        zone.GetComponent<CameraZone>().index = zones.Count - 1;
        return zone;
    }
}
