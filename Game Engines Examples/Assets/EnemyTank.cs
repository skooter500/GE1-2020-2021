using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float radius = 5.0f;
    public int waypointCount = 6;
    public GameObject waypointPrefab;
    public float tankSpeed = 5.0f;
    public Transform target;
    public float fov = 60;

    private int currentWaypoint = 0;
    private float rotationSpeed = 5f;
    private Quaternion lookRotation;
    private Vector3 direction;

    private static StringBuilder message = new StringBuilder();

    private void OnGUI()
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
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.position = this.transform.position;

        float theta = Mathf.PI * 2.0f / (float) waypointCount;

        for (int i = 0; i < waypointCount; i++)
        {
            float angle = i * theta;
            GameObject g = GameObject.Instantiate<GameObject>(waypointPrefab);
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            g.transform.position = transform.TransformPoint(pos);
            g.transform.parent = waypoints.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move tank position a step closer to the target
        GameObject waypoints = GameObject.Find("Waypoints");
        Transform targetWaypoint = waypoints.gameObject.transform.GetChild(currentWaypoint);

        float step = tankSpeed * Time.deltaTime;

        direction = (targetWaypoint.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);


        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypoint += 1;
            if(currentWaypoint >= 6)
            {
                currentWaypoint = 0;
            }
        }

        // float targetDist = (target.transform.position - transform.position).magnitude;
        Vector3 targetDirection = target.position - transform.position;
        float angle = Vector3.Angle(targetDirection, transform.forward);
        if (angle > fov)
        {
            message.Append("Target is behind\n");
            message.Append("Angle to target: " + angle + "\n");
            message.Append("Player is outside the FOV");
        }
        else
        {
            message.Append("Target is ahead\n");
            message.Append("Angle to target: " + angle + "\n");
            message.Append("Player is within FOV");
        }
        
    }
}
