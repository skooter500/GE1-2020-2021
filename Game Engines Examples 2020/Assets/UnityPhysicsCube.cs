using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPhysicsCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float time = 0;
    public Rigidbody rb; 

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            time += Time.deltaTime;
        }
        else
        {
            rb.isKinematic = true;
            Debug.Log("Unity physics cube time += " + time);
            Debug.Log("Unity physics cube velociy: " + rb.velocity);    
        }
    }
}
