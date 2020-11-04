using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThing : MonoBehaviour
{
    public int elements = 12;
    public float radius = 10;
    // Start is called before the first frame update
    void Start()
    {
        float theta = Mathf.PI * 2.0f / (float) elements;
        for(int i = 0 ; i < elements ; i ++)
        {
            GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            sp.transform.position = transform.TransformPoint(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
