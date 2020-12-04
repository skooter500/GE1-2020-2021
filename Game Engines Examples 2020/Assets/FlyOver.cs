using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOver : MonoBehaviour {

    public float maintainHeight = 100;
    public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit rch;
        if (Physics.Raycast(transform.position, -Vector3.up, out rch))
        {
            // First do the physics
            Vector3 targetPos = transform.position;
            targetPos += (Vector3.forward * speed * Time.deltaTime);
            targetPos.y = Mathf.Lerp(targetPos.y, rch.point.y + maintainHeight, Time.deltaTime * 2);
            transform.position = targetPos;
        }
	}
}
