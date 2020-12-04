using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlane : MonoBehaviour {

    private void Awake()
    {
        m = GetComponent<MeshFilter>().mesh;

        ReSample();
    }

    Mesh m;

    // Use this for initialization
    void ReSample() {
        
        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell0(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z);
        }
        m.vertices = vertices;
        m.RecalculateBounds();
        m.RecalculateNormals();
    }

    void Update () {
        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell0(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z + t);
        }
        m.vertices = vertices;
        t += Time.deltaTime;
        m.RecalculateNormals();
	}

    float t = 0;
        

    public static float SampleCell0(float x, float y)
    {
                return 
         Mathf.PerlinNoise((10000 + x) / 5, (10000 + y) / 5) * 5;

        /*
        return Mathf.Sin(Utilities.Map(x, 0, 10, 0, Mathf.PI))
        * Mathf.Sin(Utilities.Map(y, 0, 10, 0, Mathf.PI)) * 1;
        */
    }
}
