using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTransform : MonoBehaviour
{

    public Matrix4x4 vertTranform = Matrix4x4.identity;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3[] verts = meshFilter.mesh.vertices;
        List<Vector3> newVerts = new List<Vector3>();
        foreach (Vector3 vert in verts) {
            Vector3 transformed = vertTranform.MultiplyPoint3x4(vert);
            newVerts.Add(transformed);
        }
        meshFilter.mesh.SetVertices(newVerts);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
