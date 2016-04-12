using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class tilemap : MonoBehaviour
{

    private int xSize, ySize;
    public int xGrid, yGrid;
    public int xRes, yRes;


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

    struct Tile
    {

        public int x;
        public int y;

        public Tile(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    }

    private Mesh mesh;
    private Vector2[] uv;
    private void Generate()
    {
        xSize = xRes / xGrid;
        ySize = yRes / yGrid;

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Moop";


        Vector3[] vertices = new Vector3[xSize * ySize * 4];
        uv = new Vector2[xSize * ySize * 4];
        int[] triangles = new int[xSize * ySize * 6];

        Tile[,] tiles = new Tile[,]
        {
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(0,1),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(0,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(0,1),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(0,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(0,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(0, 0),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)},
            {new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1),new Tile(1,0),new Tile(1, 1)}
        };

        Debug.Log("Moop: " + tiles.Length);

        for (int i = 0, ti = 0, y = 0; y < ySize; y++)
        {

            for (int x = 0; x < xSize; x++, i+=4, ti+=6)
            {

                vertices[i] = new Vector3(x*xGrid-xRes/2, y*yGrid-yRes/2);
                vertices[i+1] = new Vector3(x*xGrid-xRes/2, (y+1)*yGrid-yRes/2);
                vertices[i+2] = new Vector3((x+1)*xGrid-xRes/2, (y+1)*yGrid-yRes/2);
                vertices[i+3] = new Vector3((x+1)*xGrid-xRes/2, y*yGrid-yRes/2);
                Debug.Log("x: " + tiles[y,x].x + "/ y: " + tiles[y,x].y);
                uv[i] = new Vector2( ( tiles[y,x].x ) * 0.055555555F, ( tiles[y,x].y ) * 0.055555555F);
                uv[i+1] = new Vector2( ( tiles[y,x].x ) * 0.055555555F, ( tiles[y,x].y + 1 ) * 0.055555555F);
                uv[i+2] = new Vector2( ( tiles[y,x].x + 1 ) * 0.055555555F, ( tiles[y,x].y + 1 ) * 0.055555555F);
                uv[i+3] = new Vector2( ( tiles[y,x].x + 1 ) * 0.055555555F, ( tiles[y,x].y ) * 0.055555555F);
                // uv[i] = new Vector2((float)x/xSize, (float)y/ySize);
                // uv[i+1] = new Vector2((float)x/xSize, (float)(y+1)/ySize);
                // uv[i+2] = new Vector2((float)(x+1)/xSize, (float)(y+1)/ySize);
                // uv[i+3] = new Vector2((float)(x+1)/xSize, (float)y/ySize);
                triangles[ti] = i;
                triangles[ti+1] = i+1;
                triangles[ti+2] = i+2;
                triangles[ti+3] = i;
                triangles[ti+4] = i+2;
                triangles[ti+5] = i+3;

            }
        }

        // int[] triangles = new int[xSize * ySize * 6];
        //
        // for (int 
        // for (int ti = 0, vi = 0, y = 0; y < ySize; y++, ti += 6, vi++)
        // {
        //
        //     for (int x = 0; x < xSize; x++, ti += 6, vi++)
        //     {
        //         triangles[ti] = vi;
        //         triangles[ti + 3] = triangles[ti + 2] = vi + 1;
        //         triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
        //         triangles[ti + 5] = vi + xSize + 2;
        //     }
        //
        // }
        //

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        LoadThing();
    }


    private void LoadThing()
    {
        // uv = new Vector2[vertices.Length];
        //
        Texture2D tm = (Texture2D)Resources.Load("Graphics/TM1");
        //
        // List<int> mapping = new List<int>();
        // mapping.Add(2);
        // mapping.Add(1);
        //
        // // OMG, LOTS TO DO HERE
        // // Step 1: Figure out a way how to compartmentalize tiles from their respective vertices and UV's !!
        // //
        // // for (int j = 0; j <= mapping.Length/xSize; j++)
        // // {
        // //
        // //     for (int i = 0; i < xSize & i < mapping.Length; i++)
        // //     {
        // //         if (mapping[j+i] == null) { break; }
        // //         uv[j+i] = new Vector2(mapping[j+i] * , );
        // //     }
        // //
        // // }
        //
        // uv[0] = new Vector2((float)(1/32), 0);
        // uv[1] = new Vector2((float)(1/32), (float)(1/32));
        // uv[2] = new Vector2((float)(2*1/32), (float)(1/32));
        // uv[3] = new Vector2((float)(2*1/32), 0);
        // mesh.uv = uv;
        gameObject.GetComponent<Renderer>().material.mainTexture = tm;

    }

}
