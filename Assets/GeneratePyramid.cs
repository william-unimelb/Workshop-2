using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeneratePyramid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreateMesh();
    }

    private Mesh CreateMesh() {
        var mesh = new Mesh {
            name = "Pyramid"
        };

        mesh.SetVertices(new[] {
            // Front face
            new Vector3(0, 1, 0),
            new Vector3(1, -1, -1),
            new Vector3(-1, -1, -1),

            // Left face
            new Vector3(0, 1, 0),
            new Vector3(1, -1, 1),
            new Vector3(1, -1, -1),

            // Right face
            new Vector3(0, 1, 0),
            new Vector3(-1, -1, -1),
            new Vector3(-1, -1, 1),

            // Back face
            new Vector3(0, 1, 0),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),

            // Base
            new Vector3(1, -1, -1),
            new Vector3(1, -1, 1),
            new Vector3(-1, -1, 1),

            new Vector3(1, -1, -1),
            new Vector3(-1, -1, 1),
            new Vector3(-1, -1, -1)
        });

        mesh.SetColors(new[] {
            // Front face
            Color.blue,
            Color.blue,
            Color.blue,

            // Left face
            Color.red,
            Color.red,
            Color.red,

            // Right face
            Color.green,
            Color.green,
            Color.green,

            // Back face
            Color.yellow,
            Color.yellow,
            Color.yellow,

            // Base
            Color.white,
            Color.white,
            Color.white,

            Color.white,
            Color.white,
            Color.white
        });

        var indices = Enumerable.Range(0, mesh.vertices.Length).ToArray();
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        return mesh;
    }
}
