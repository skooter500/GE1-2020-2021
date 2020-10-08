using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float power = 2;
    public float maxSpeed = 5;
    
    Vector3 velocity = Vector3.zero;

    void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Speed:" + velocity.magnitude);                
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += transform.forward * Input.GetAxis("Vertical") * power; 
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        
        if (velocity.magnitude > 0)
        {
            transform.position += velocity * Time.deltaTime;    
        }
        
        
    }
}
