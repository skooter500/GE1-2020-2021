using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotator : MonoBehaviour {
    public float angle = 20;
    public float frequency = 1;
	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        StartCoroutine(VaryTentacles());
    }

    IEnumerator VaryTentacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
            frequency = Random.Range(0.1f, 0.5f);
            angle = Random.Range(10.0f, 70f);
        }
    }


    public float theta = 0;
	// Update is called once per frame
	void Update () {
        
        //transform.Translate(0, , 0);
        transform.localRotation = 
            Quaternion.AngleAxis(Mathf.Sin(theta) * angle, Vector3.right);
        // Set the transform local rotation field
        // From a Quaternion that rotates around the Vector3.Right vector
        // Use a sine wave function to calculate the angle
        // Using theta, and amplitude
        // Add to theta according to frequency. 
        // If the frequency was 2 for example, theta needs to go
        // between 0 and 2 PI twice a second
        theta += Mathf.PI * 2.0f * Time.deltaTime * frequency;
	}
}
