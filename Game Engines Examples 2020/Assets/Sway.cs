using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public bool useJobSystem = false;  
    public float angle = 30;
    public float frequency = 1;

    float theta = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (useJobSystem)
        {
            SwayJobManager.Instance.Add(this);
        }
    }

    // Update is called once per frame
    

    void Update()
    {
        if (! useJobSystem)
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Sin(theta) * angle, transform.right);
            theta += Mathf.PI * 2.0f * Time.deltaTime * frequency;
        }
    }
    
}
