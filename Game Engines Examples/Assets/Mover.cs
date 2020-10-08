using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject target;
    public float speed = 5;

    private static StringBuilder message = new StringBuilder();

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
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        message.Append("Distance to target: " + distanceToTarget + "\n");
        Vector3 totarget = target.transform.position - transform.position;
        message.Append("To target: " + totarget + "\n");
        totarget.Normalize();
        message.Append("Normalized: " + totarget + "\n");
        
        /*
        if (distanceToTarget > 0.1f)
        {
            transform.position += totarget * speed * Time.deltaTime;
        }
        */

        // Or try this:
        /*
        transform.LookAt(target.transform);            
        if (distanceToTarget > 0.1f)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
    
        }
        */

        // Angle using dot product:
        float dot = Vector3.Dot(transform.forward, totarget);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        message.Append("Angle using dot product: " + angle + "\n"); 

        float angle1 = Vector3.Angle(transform.forward, totarget);
        message.Append("Angle using angle between: " + angle1 + "\n");

        Vector3 axis = Vector3.Cross(transform.forward, totarget);
        message.Append("Axis: " + axis + "\n");
        float angle2 = Vector3.SignedAngle(transform.forward, totarget, axis);
        message.Append("Signed Angle: " + angle2 + "\n");

        
        


        
    }
}
