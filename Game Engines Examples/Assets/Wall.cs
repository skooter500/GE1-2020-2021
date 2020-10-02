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

        for(int i = -halfWidth ; i < halfWidth ; i ++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(i, 0.5f, 0);
            cube.GetComponent<Renderer>().material.color = 
                Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
            cube.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
