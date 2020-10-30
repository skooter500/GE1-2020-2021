using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(toTarget, transform.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        Vector3 axis = Vector3.Cross(transform.forward, toTarget);

        Quaternion q = Quaternion.AngleAxis(angle, axis);
        transform.rotation = q;

        // Do all the above in one line!
        transform.LookAt(target); // Takes a transform
        transform.rotation = Quaternion.LookRotation(toTarget); // Takes a vector

        Quaternion q1 = Quaternion.AngleAxis(90, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(90, Vector3.right);
        transform.rotation = q1 * q2;

        Vector3 v = new Vector3(0, 0, 10);
        v = q1 *q2 * v;
        Debug.Log(v);

    }

    

    void Update()
    {
    }
}
