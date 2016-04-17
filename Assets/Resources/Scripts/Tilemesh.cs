using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Tilemesh : MonoBehaviour
{
    public int xGrid, yGrid;
    public int xRes, yRes;
    public string tileMap;
    public string map;

	private void Awake()
    {
        Generate();
    }

    private Mesh mesh;
    private Vector2[] uv;
    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Tilemesh";

        Texture2D tm = (Texture2D)Resources.Load("Tilemaps/" + tileMap);
        gameObject.GetComponent<Renderer>().material.mainTexture = tm;
        int tileNumX = tm.width / xGrid;
        int tileNumY = tm.height / yGrid;

        int xSize = 0;
        int ySize = 0;
        List<int> temp = new List<int>();

        try
        {
            using (StreamReader mapParser = new StreamReader("Assets/Resources/Maps/" + map + ".csv") )
            {
                string line;

                while ( (line = mapParser.ReadLine() ) != null )
                {
                    temp.AddRange(line.Split(',').Select( i => int.Parse(i) ) );
                    ySize++;
                }


            }

        }

        catch (Exception e)
        {
            Debug.Log(e);
        }

        int[] tiles = temp.ToArray();

        Globalscript.Instance.tilesX = xSize = tiles.Length / ySize;
        Globalscript.Instance.tilesY = ySize;
        Globalscript.Instance.dimX = xGrid;
        Globalscript.Instance.dimY = yGrid;
        Globalscript.Instance.pixelsX = xSize * xGrid;
        Globalscript.Instance.pixelsY = ySize * yGrid;

        Vector3[] vertices = new Vector3[xSize * ySize * 4];
        uv = new Vector2[xSize * ySize * 4];
        int[] triangles = new int[xSize * ySize * 6];

        for (int i = 0, ti = 0, vi = 0, y = ySize; y > 0; y--)
        {

            for (int x = 0; x < xSize; x++, vi++, ti+=6, i+=4)
            {

                vertices[i] = new Vector3
                    (
                        ( ( x + 0 ) * xGrid - ( xSize * xGrid) / 2 ),
                        ( ( y - 0 ) * yGrid - ( ySize * yGrid) / 2 )
                    );
                vertices[i+1] = new Vector3
                    (
                        ( ( x + 0 ) * xGrid - ( xSize * xGrid) / 2 ),
                        ( ( y - 1 ) * yGrid - ( ySize * yGrid) / 2 )
                    );
                vertices[i+2] = new Vector3
                    (
                        ( ( x + 1 ) * xGrid - ( xSize * xGrid) / 2 ),
                        ( ( y - 1 ) * yGrid - ( ySize * yGrid) / 2 )
                    );
                vertices[i+3] = new Vector3
                    (
                        ( ( x + 1 ) * xGrid - ( xSize * xGrid) / 2 ),
                        ( ( y - 0 ) * yGrid - ( ySize * yGrid) / 2 )
                    );
                uv[i] = new Vector2
                    (
                        (float)( (double)( tiles[vi]%tileNumX + 0 ) * ( (double)xGrid / (double)tm.width) ),
                        (float)( (double)tm.height - ( (double)( Mathf.FloorToInt( tiles[vi] / tileNumY ) + 0F ) * ( (double)yGrid / (double)tm.height) ) )
                    );
                uv[i+1] = new Vector2
                    (
                        (float)( (double)( tiles[vi]%tileNumX + 0 ) * ( (double)xGrid / (double)tm.width) ),
                        (float)( (double)tm.height - ( (double)( Mathf.FloorToInt( tiles[vi] / tileNumY ) + 1F ) * ( (double)yGrid / (double)tm.height) ) )
                    );
                uv[i+2] = new Vector2
                    (
                        (float)( (double)( tiles[vi]%tileNumX + 1 ) * ( (double)xGrid / (double)tm.width) ),
                        (float)( (double)tm.height - ( (double)( Mathf.FloorToInt( tiles[vi] / tileNumY ) + 1F ) * ( (double)yGrid / (double)tm.height) ) )
                    );
                uv[i+3] = new Vector2
                    (
                        (float)( (double)( tiles[vi]%tileNumX + 1 ) * ( (double)xGrid / (double)tm.width) ),
                        (float)( (double)tm.height - ( (double)( Mathf.FloorToInt( tiles[vi] / tileNumY ) + 0F ) * ( (double)yGrid / (double)tm.height) ) )
                    );
                triangles[ti] = i;
                triangles[ti+1] = i+1;
                triangles[ti+2] = i+2;
                triangles[ti+3] = i;
                triangles[ti+4] = i+2;
                triangles[ti+5] = i+3;

            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }

}
