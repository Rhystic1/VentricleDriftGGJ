using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhotoMesh : MonoBehaviour
{
    public int width = 2048;
    public int height = 2048;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Custom Plane";
        mesh.vertices = new Vector3[]
        {
            new Vector3(-width / 2f, 0, -height / 2f),
            new Vector3(-width / 2f, 0, height / 2f),
            new Vector3(width / 2f, 0, height / 2f),
            new Vector3(width / 2f, 0, -height / 2f)
        };
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mesh.RecalculateNormals();

        GameObject plane = new GameObject("Plane", typeof(MeshFilter), typeof(MeshRenderer));
        plane.GetComponent<MeshFilter>().mesh = mesh;
        plane.transform.position = Vector3.zero;
    }
}
