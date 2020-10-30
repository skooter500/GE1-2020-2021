using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    public Transform target;
    float t = 0;
    float time = 5.0f;
    float speed = 5;
    Quaternion start;
    Quaternion end;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.rotation;
        
        toTarget = target.position - transform.position;
        Quaternion q = Quaternion.AngleAxis(90, Vector3.up);
        Quaternion q1 = Quaternion.AngleAxis(90, Vector3.right);
        end = Quaternion.LookRotation(toTarget);        
        //transform.LookAt(target);
        //transform.rotation = Quaternion.LookRotation(toTarget);

        toTarget.Normalize();
        axis = Vector3.Cross(transform.forward, toTarget);
        dot = Vector3.Dot(toTarget, transform.forward);
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        //angle *= Mathf.Rad2Deg;
        Quaternion q2 = Quaternion.AngleAxis(angle, axis);

        toTarget = target.position - transform.position;
        axis = Vector3.Cross(transform.forward, toTarget);
        dot = Vector3.Dot(toTarget, transform.forward);
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        
        //transform.rotation = q2;

    }

    Vector3 axis;
    Vector3 toTarget;
    float angle;
    float dot;
    // Update is called once per frame
    void Update()
    {
        //angle *= Mathf.Rad2Deg;
        
        GameManager.Log("ToTarget: " + toTarget);
        GameManager.Log("Axis: " + axis);
        GameManager.Log("Dot: " + dot);
        GameManager.Log("Angle: " + angle);

        //transform.rotation = Quaternion.Slerp(transform.rotation, end, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, end, speed * Time.deltaTime);

        /*
        if (t < 1)
        {
            transform.rotation = Quaternion.Slerp(start, end, t);
            t += Time.deltaTime * (1/time);
        }
        */
                
    }
}
