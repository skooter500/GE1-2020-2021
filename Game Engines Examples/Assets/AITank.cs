using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public int numwaypoints = 5;
    public float radius = 10;

    public int current = 0;
    public float speed = 10;
    public List<Vector3> waypoints = new List<Vector3>();
    public Transform player;
    void Start()
    {
        MakeWaypoints();
    }

    void MakeWaypoints()
    {
        waypoints.Clear();
        float thetaInc = (Mathf.PI * 2) / numwaypoints;
        for (int i = 0; i < numwaypoints; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            MakeWaypoints();
            for (int i = 0; i < waypoints.Count; i++)
            {
                Gizmos.DrawWireSphere(waypoints[i], 2);
            }
        }
    }
    void Update()
    {
        Vector3 toTarget = waypoints[current] - transform.position;
        GameManager.Log("To waypoint: " + toTarget.magnitude);
        if (toTarget.magnitude < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        toTarget.Normalize();
        transform.forward = toTarget;
        transform.Translate(toTarget * speed * Time.deltaTime, Space.World);

        Vector3 toPlayer = player.position - transform.position;
        if (Vector3.Dot(transform.forward, toPlayer) < 0)
        {
            GameManager.Log("Player is behind");
        }
        else
        {
            GameManager.Log("Player is in front");
        }
        float angle = Mathf.Acos(Vector3.Dot(transform.forward, toPlayer) / toPlayer.magnitude) * Mathf.Rad2Deg;
        GameManager.Log("Angle to player 1: " + angle);
        if (angle < 45)
        {
            GameManager.Log("Player is inside the FOV");
        }
        else
        {
            GameManager.Log("Player is outside the FOV");
        }
    }
}
