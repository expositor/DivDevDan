using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class tilemap : MonoBehaviour
{

    private int xSize, ySize;
    public int xGrid, yGrid;
    public int xRes, yRes;

    private Vector3[] vertices;
    private Vector2[] uv;
    private Color32[] colors;

    private RectTransform rt;

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
        uv = new Vector2[vertices.Length];

        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x*xGrid-xRes/2, y*yGrid-yRes/2, 0);
                uv[i] = new Vector2(x, y);
            }
        }

        int[] triangles = new int[xSize * ySize * 12];

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

        // colors = new Color32[(xSize + 1) * (ySize + 1)];
        // for (int i = 0, y = 0; y <= ySize; y++, i += xSize+1)
        // {
        //     for (int x = 0; x <= xSize; x++)
        //     {
        //         colors[i + x] = new Color32((byte)(255/(xSize+1)*x),(byte)(255/(ySize+1)*y),0,255);
        //     }
        // }
        //
        // for (int i = 0; i < xSize; i++)
        // {
        //     colors[i] = colors[i+1] = colors[i+xSize+1] = colors[i+xSize+2] = new Color32((byte)(i * 255/xSize), 0, 0, 255);
        // }

        Texture2D tex = (Texture2D)Resources.Load("Graphics/Bulbingsworth");

        gameObject.GetComponent<Renderer>().material.mainTexture = tex;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.colors32 = colors;

    }

}
