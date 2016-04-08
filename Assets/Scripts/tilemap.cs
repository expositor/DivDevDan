using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class tilemap : MonoBehaviour
{

    private int xSize, ySize;
    public int xGrid, yGrid;
    public int xRes, yRes;

    private Vector3[] vertices;
    public RectTransform rt;

	void Start ()
	{
        rt = transform.parent.GetComponent<RectTransform>();
	}

	void Update ()
	{
	}

	private void Awake()
    {
        Generate();
    }

    private Mesh mesh;
    private void Generate()
    {
        xSize = xRes / xGrid;
        ySize = yRes / yGrid;

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Moop";

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x*xGrid-xRes/2, y*yGrid-yRes/2, 0);
            }
        }

        mesh.vertices = vertices;
        int[] triangles = new int[xSize * ySize * 6 * 2];

        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, ti += 6, vi++)
        {

            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }

        }

        mesh.triangles = triangles;

    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        Gizmos.color = Color.white;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(rt.TransformPoint(vertices[i]), 0.1F);
        }

    }

}
