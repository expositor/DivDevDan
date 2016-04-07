using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class tilemap : MonoBehaviour
{

    public int xSize, ySize;

	void Start ()
	{
	}

	void Update ()
	{
	}

	private void Awake()
    {
        Generate();
    }

    private Vector3[] vertices;

    private void Generate()
    {
        // RectTransform rt = GetComponent<RectTransform>();

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
            }
        }

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
            Gizmos.DrawSphere(vertices[i], 0.2F);
        }

    }

}
