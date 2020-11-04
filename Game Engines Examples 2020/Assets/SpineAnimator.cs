using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimator : MonoBehaviour {
    public List<Vector3> offsets = new List<Vector3>();
    public List<Transform> children = new List<Transform>();
    public float damping = 10.0f;

    public bool useSpineAnimatorSystem = false;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform current = transform.GetChild(i);
            if (i > 0)
            {
                Transform prev = transform.GetChild(i - 1);
                Vector3 offset = current.transform.position - prev.transform.position; 
                offset = Quaternion.Inverse(prev.transform.rotation) * offset;
                offsets.Add(offset);                
            }            
            children.Add(current);
        }
        if (useSpineAnimatorSystem)
        {
            SpineAnimatorManager.Instance.AddSpine(this);
        }
    }

    // Update is called once per frame
    void Update () {
        if (useSpineAnimatorSystem)
        {
            return;
        }
        for (int i = 1; i < children.Count; i++)
        {
            Transform prev = children[i - 1];
            Transform current = children[i];
            Vector3 wantedPosition = prev.position + ((prev.rotation * offsets[i-1]));
            Quaternion wantedRotation = Quaternion.LookRotation(prev.transform.position - current.position, prev.transform.up);

            Vector3 lerpedPosition = Vector3.Lerp(current.position, wantedPosition, Time.deltaTime * damping);
            Vector3 clampedOffset = lerpedPosition - prev.position;
            clampedOffset = Vector3.ClampMagnitude(clampedOffset, offsets[i-1].magnitude);
            current.position = prev.position + clampedOffset;


            current.rotation = Quaternion.Slerp(current.rotation, wantedRotation, Time.deltaTime * damping);
        }
    }
}
