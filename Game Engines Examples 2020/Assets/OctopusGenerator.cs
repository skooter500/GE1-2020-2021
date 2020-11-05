using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusGenerator : MonoBehaviour {

    public int numTentacles = 8;
    public float radius = 2;
    public GameObject tentaclePrefab;
	// Use this for initialization
	void Start () {
        float theta = (Mathf.PI * 2.0f) / numTentacles;
        
        for (int i = 0; i < numTentacles; i++)
        {
            // Calculate the localPosition using Sin and Cos
            // Transform the localPosition relative to the gameobject
            // To make the position of the tentacle
            // You can use TransformPoint or you can use quaternions!
            // Instiantiate the tentacle
            // Dont forget to set it's rotation!
            // You can use Quaternion.AngleAxis for this
            // Parent the tentacle to this gameobject
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
