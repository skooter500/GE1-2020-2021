using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    // Start is called before the first frame update
    void Start()
    {
        int halfWidth = width / 2;

        for(int j = 0 ; j < height ; j ++)
        {
            for(int i = -halfWidth ; i < halfWidth ; i ++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Vector3 pos = transform.TransformPoint(new Vector3(i, 0.5f + j, 0));
                cube.transform.position = pos;
                cube.transform.rotation = transform.rotation;
                cube.GetComponent<Renderer>().material.color = 
                    Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
                cube.AddComponent<Rigidbody>();
                cube.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
