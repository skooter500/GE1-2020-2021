using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour {

    public int quadsPerTile = 10;

    public Material meshMaterial;

    public float amplitude = 50;

    Mesh m;

    private delegate float SampleCell(float x, float y);

    SampleCell[] sampleCell = {
              new SampleCell(SampleCell0)
              , new SampleCell(SampleCell1)
              , new SampleCell(SampleCell2)
              , new SampleCell(SampleCell3)
              , new SampleCell(SampleCell4)
    };

    public int whichSampler = 0;

    // Use this for initialization
    void Awake() {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>(); // Container for the mesh
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>(); // Draw
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        m = mf.mesh;

        int verticesPerQuad = 4;
        Vector3[] vertices = new Vector3[verticesPerQuad * quadsPerTile * quadsPerTile];
        Vector2[] uv = new Vector2[verticesPerQuad * quadsPerTile * quadsPerTile];

        int vertexTriangesPerQuad = 6;
        int[] triangles = new int[vertexTriangesPerQuad * quadsPerTile * quadsPerTile];

        Vector3 bottomLeft = new Vector3(-quadsPerTile / 2, 0, -quadsPerTile / 2);
        int vertex = 0;
        int triangleVertex = 0;
        float minY = float.MaxValue;
        float maxY = float.MinValue;
        for (int row = 0; row < quadsPerTile; row++)
        {
            for (int col = 0; col < quadsPerTile; col++)
            {
                Vector3 bl = bottomLeft + new Vector3(col, sampleCell[whichSampler](transform.position.x + col, transform.position.z + row), row);
                Vector3 tl = bottomLeft + new Vector3(col, sampleCell[whichSampler](transform.position.x + col, transform.position.z + row + 1), row + 1);
                Vector3 tr = bottomLeft + new Vector3(col + 1, sampleCell[whichSampler](transform.position.x + col + 1, transform.position.z + row + 1), row + 1);
                Vector3 br = bottomLeft + new Vector3(col + 1, sampleCell[whichSampler](transform.position.x + col + 1, transform.position.z + row), row);

                int startVertex = vertex;
                vertices[vertex++] = bl;
                vertices[vertex++] = tl;
                vertices[vertex++] = tr;
                vertices[vertex++] = br;
                               

                vertex = startVertex;
                float fNumQuads = quadsPerTile;
                uv[vertex++] = new Vector2(col / fNumQuads, row / fNumQuads);
                uv[vertex++] = new Vector2(col / fNumQuads, (row + 1) / fNumQuads);
                uv[vertex++] = new Vector2((col + 1) / fNumQuads, (row + 1) / fNumQuads);
                uv[vertex++] = new Vector2((col + 1) / fNumQuads, row / fNumQuads);

                triangles[triangleVertex++] = startVertex;
                triangles[triangleVertex++] = startVertex + 1;
                triangles[triangleVertex++] = startVertex + 3;
                triangles[triangleVertex++] = startVertex + 3;
                triangles[triangleVertex++] = startVertex + 1;
                triangles[triangleVertex++] = startVertex + 2;

                if (bl.y > maxY)
                {
                    maxY = bl.y;
                }
                if (bl.y < minY)
                {
                    minY = bl.y;
                }
            }
        }
        m.vertices = vertices;
        m.uv = uv;
        m.triangles = triangles;        
        m.RecalculateNormals();
        mr.material = meshMaterial;
        mc.sharedMesh = m;
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        mr.receiveShadows = true;
	}


    // SHould really make a new class for all this!
    
    // Sample with a sine wave
    public static float SampleCell0(float x, float y)
    {

        return Mathf.Sin(Utilities.Map(x, 0, 100, 0, Mathf.PI))
        * Mathf.Sin(Utilities.Map(y, 0, 100, 0, Mathf.PI)) * 40;
    }

    // Additive perlin noise
    public static float SampleCell1(float x, float y)
    {
        return (
         Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100) * 100)
         + (Mathf.PerlinNoise(10000 + x / 1000, 10000 + y / 1000) * 300)
         + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }

    // Mountains and valleys
    public static float SampleCell2(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100);
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
        }
        return (noise * 300);
    }

    // Mountains and valleys & bumps
    public static float SampleCell3(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100);
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
        }
        
        return (noise * 300) + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }

    public static float SampleCell4(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x , 10000 + y );
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
        }
        
        return (noise * 300) + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }
    float t = 0;
	// Update is called once per frame   
    
    /*        
	void Update () {
        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z + t);
        }
        m.vertices = vertices;
        //t += Time.deltaTime;
        m.RecalculateNormals();
	}
    */
}
