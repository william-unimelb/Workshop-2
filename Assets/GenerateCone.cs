using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCone : MonoBehaviour
{

    public float height = 2;
    public float radius = 1;
    public int baseVertices = 8;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreateMesh();
    }

    private Mesh CreateMesh() {
        var mesh = new Mesh {
            name = "Cone"
        };

        // Create list for verts with apex
        List<Vector3> verts = new List<Vector3>() { new Vector3(0, height, 0) };

        // Add each vert in the circle
        for (int i = 0; i < baseVertices; ++i) {
            float theta = i * (2.0f*Mathf.PI/baseVertices);
            Vector3 vertex = new Vector3(radius*Mathf.Cos(theta), 0, radius*Mathf.Sin(theta));
            verts.Add(vertex);
        }

        mesh.SetVertices(verts);

        // Colour each vertex
        List<Color> colors = new List<Color>() { Color.white };

        for (int i = 0; i < baseVertices; ++i) {
            colors.Add(Color.HSVToRGB(((float)i) / baseVertices, 1, 1));
        }
        mesh.SetColors(colors);

        // Create indices
        List<int> indices = new List<int>();

        // Draw the side faces
        for (int i = 0; i < baseVertices; ++i) {
            int current = i + 1; 
            int next = (i + 1) % baseVertices + 1;
            int apex = 0;
            indices.Add(apex);
            indices.Add(next);
            indices.Add(current);
        }

        // Draw the base
        for (int i = 1; i < baseVertices - 1; ++i) {
            int current = i + 1;
            int next = current + 1;
            int first = 1;
            indices.Add(first);
            indices.Add(current);
            indices.Add(next);
        }

        mesh.SetIndices(indices.ToArray(), MeshTopology.Triangles, 0);

        return mesh;
    }

}
