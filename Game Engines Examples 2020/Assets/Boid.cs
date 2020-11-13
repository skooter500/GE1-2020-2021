using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass  = 1.0f;
    public float max = 5;

    public Transform target;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + force);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
        
    }

    public Vector3 Seek(Transform target)
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= max;

        return desired - velocity;
    }


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        force = Seek(target);

        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
