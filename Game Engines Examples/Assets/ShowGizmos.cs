using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draw a semitransparent yellow cube at the transforms position
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
