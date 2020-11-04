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
        
        transform.localRotation =
            Quaternion.AngleAxis(
                Mathf.Sin(theta) * angle, Vector3.right);
        /*
         * transform.rotation = Quaternion.AngleAxis(
                Mathf.Sin(theta) * angle, transform.right);
            */

        theta += frequency * Mathf.PI * 2.0f * Time.deltaTime;
	}
}
