using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwaySpawner : MonoBehaviour
{
    int row;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int columns = 1000; 

    public void CreateRow()
    {
        int half = columns / 2;
        for(int i = -half; i < half; i ++)
        {
            Vector3 pos = new Vector3(i, 0, row) * 5;
            pos = transform.TransformPoint(pos);
            GameObject g = GameObject.Instantiate<GameObject>(prefab, pos, Quaternion.identity);
            g.transform.parent = this.transform;
        }
        row++;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 50), "Count: " + row * columns);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRow();
        }
    }
}
