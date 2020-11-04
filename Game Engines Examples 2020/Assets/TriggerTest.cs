using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Triggered with: " + c.gameObject.tag);
    }

    void OnTriggerStay(Collider c)
    {
        Debug.Log("Stay with: " + c.gameObject.tag);
    }

    void OnTriggerExit(Collider c)
    {
        Debug.Log("No longer Triggered with: " + c.gameObject.tag);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
