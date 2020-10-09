using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private static StringBuilder message = new StringBuilder();

    public float speed = 5.0f;
    public float time = 3.0f;
    public Transform target;

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dist = (target.transform.position - transform.position).magnitude;
        speed = dist / time;
    }

    float dist;

    // Update is called once per frame
    void Update()
    {
        float dist1 = Vector3.Distance(target.position, transform.position);
        message.Append("Dist via vectors: " + dist + "\n");
        
        message.Append("Dist via dist: " + dist1 + "\n");
        /*
        Vector3 toTarget = target.position - transform.position;
        toTarget.Normalize();

        if (dist > 0.1f)
        {
            transform.position += toTarget * speed * Time.deltaTime;
        }
        */
        /*
        transform.LookAt(target.position);
        
        if (dist > 0.1f)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        */

        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(transform.forward, toTarget);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        message.Append("Angle: " + angle + "\n");

        float angle1 = Vector3.Angle(transform.forward, toTarget);
        message.Append("Angle using API: " + angle + "\n");

        float signedAngle = Vector3.SignedAngle(transform.forward, toTarget, Vector3.up);
        message.Append("Signed Angle using API: " + angle + "\n");

        if (dot >= 0)
        {
            message.Append("In front");
        }
        else
        {
            message.Append("behind");
        }

    }
}
