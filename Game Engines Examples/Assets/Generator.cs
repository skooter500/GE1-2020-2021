using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        int radius = 1;
        for(int i = 1 ; i <= loops ; i ++)
        {
            int numPrefabs = (int)(2.0f * Mathf.PI * i * radius);
            float theta = Mathf.PI * 2.0f / ((float)numPrefabs);
            for (int j = 0 ; j < numPrefabs ; j ++)
            {
                float angle  = j * theta; 
                float x = Mathf.Sin(angle) * radius * (i) * 1.1f;
                float y = Mathf.Cos(angle) * radius * (i) * 1.1f;
                GameObject g = GameObject.Instantiate<GameObject>(prefab);
                g.transform.position = new Vector3(x, y, 0);
                g.GetComponent<Renderer>().material.color =
                    Color.HSVToRGB(j / (float) numPrefabs, 1, 1);
                g.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
