using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    Quaternion start;
    Quaternion end;

    float t;
    public float time = 5.0f;

    public float speed = 20.0f;
    
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        // The long way!!
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(toTarget, transform.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        Vector3 axis = Vector3.Cross(transform.forward, toTarget);


        Quaternion q = Quaternion.AngleAxis(angle, axis);
        //transform.rotation = q;

        // Do all the above in one line!
        //transform.LookAt(target); // Takes a transform
        //transform.rotation = Quaternion.LookRotation(toTarget); // Takes a vector

        Quaternion q1 = Quaternion.AngleAxis(90, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(90, Vector3.right);
        //transform.rotation = q1 * q2; // Combining rotations

        Vector3 v = new Vector3(0, 0, 10);
        v = q1 *q2 * v; // Rotating a vector by a quaternion
        Debug.Log(v);

        start = transform.rotation;
        end = Quaternion.LookRotation(toTarget);

    }

    

    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, end, Time.deltaTime);
        /*if (t < 1)
        {
            transform.rotation = Quaternion.Slerp(start, end, t);
            t += (Time.deltaTime /5.0f);
        }
        */

        transform.rotation = Quaternion.RotateTowards(transform.rotation, end, speed * Time.deltaTime);
    }
}
