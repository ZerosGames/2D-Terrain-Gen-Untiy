using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileData {

	public bool RenderDataforCol;

	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();
	public List<Vector2> uv = new List<Vector2>();
	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();

	public TileData() { }

	public void AddQuadTriangles()
	{
		triangles.Add(vertices.Count - 4);
		triangles.Add(vertices.Count - 3);
		triangles.Add(vertices.Count - 2);

		triangles.Add(vertices.Count - 4);
		triangles.Add(vertices.Count - 2);
		triangles.Add(vertices.Count - 1);

		if (RenderDataforCol) {
			colTriangles.Add(colVertices.Count - 4);
			colTriangles.Add(colVertices.Count - 3);
			colTriangles.Add(colVertices.Count - 2);

			colTriangles.Add(colVertices.Count - 4);
			colTriangles.Add(colVertices.Count - 2);
			colTriangles.Add(colVertices.Count - 1);
		}
	}

	public void AddColVertex(Vector3 vertex)
	{
		if (RenderDataforCol) {
			colVertices.Add (vertex);
		}
	}
    
    public void UpdateUV(Vector2[] OldUV, Vector2[] NewUV)
    {
        for(int i = 0; i < uv.Count; i++)
        {
            uv[i] = NewUV[i];
        }
    }

    public void AddUVs(Vector2[] FaceUVs)
    {
       uv.AddRange(FaceUVs);
    }

	public void AddVertex(Vector3 vertex)
	{
        vertices.Add (vertex);
		if (RenderDataforCol) {
			colVertices.Add (vertex);
		}
	}

	public void AddTriangle(int tri){
		triangles.Add (tri);
		if (RenderDataforCol) {
			colTriangles.Add (tri - (vertices.Count - colVertices.Count));
		}
	}
}
