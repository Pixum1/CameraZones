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
		zone.AddComponent<MeshRenderer>().materials = new Material[0];
		CreateCube(zone);
        return zone;
    }

	private void CreateCube(GameObject _obj)
	{
		Vector3[] vertices = {
			new Vector2 (-.5f, -.5f),
			new Vector2 (.5f, -.5f),
			new Vector2 (.5f, .5f),
			new Vector2 (-.5f, .5f),
		};

		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
		};

        Mesh s = new Mesh();

		_obj.AddComponent<MeshFilter>();
		_obj.GetComponent<MeshFilter>().sharedMesh = s;
		s.Clear();
		s.vertices = vertices;
		s.triangles = triangles;
		s.Optimize();
		s.RecalculateNormals();
	}
}
