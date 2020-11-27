using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz1 : MonoBehaviour {
    public float scale = 10;
    List<GameObject> elements = new List<GameObject>();
	// Use this for initialization
	void Start () {
        CreateVisualisers();

    }

    public float radius = 50;

    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float) AudioAnalyzer.frameSize;
        for (int i = 0 ; i < AudioAnalyzer.frameSize ; i ++)
        {
            Vector3 pos = new Vector3(
                Mathf.Sin(theta * i) * radius
                , 0
                , Mathf.Cos(theta * i) * radius
                
            );
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = transform.TransformPoint(pos);
            cube.transform.parent = this.transform;
            cube.GetComponent<Renderer>().material.color = 
                Color.HSVToRGB(i / (float) AudioAnalyzer.frameSize, 1, 1);
            elements.Add(cube);
        }
    }

    // Update is called once per frame
    void Update () {
        for(int i = 0 ; i < elements.Count ; i ++)
        {
            Vector3 lscale = elements[i].transform.localScale; 
            lscale.y = Mathf.Lerp(lscale.y, 1 + (Mathf.Abs(AudioAnalyzer.spectrum[i]) * scale), Time.deltaTime * 10);
            elements[i].transform.localScale = lscale;
        }
	}
}
