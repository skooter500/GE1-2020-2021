using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {

    GameObject enemyTank;

    public void Start()
    {
        enemyTank = transform.parent.gameObject;    
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "MainCamera")
        {
            collider.gameObject.GetComponent<FPSController>().enabled = false;
            enemyTank.GetComponent<TankController>().enabled = true;
            enemyTank.GetComponent<AITank>().enabled = false;
            GetComponent<RotateMe>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "MainCamera" && enemyTank.GetComponent<TankController>().enabled == true)
        {
            collider.gameObject.transform.position = Vector3.Lerp(

                collider.gameObject.transform.position
                , transform.position
                , Time.deltaTime * 3
                );
            collider.gameObject.transform.rotation = Quaternion.Slerp(
                collider.gameObject.transform.rotation
                , transform.parent.rotation
                , Time.deltaTime
                );
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyTank.GetComponent<TankController>().enabled = false;
            enemyTank.GetComponent<AITank>().enabled = true;
            collider.gameObject.GetComponent<FPSController>().enabled = true;
            GetComponent<RotateMe>().enabled = true;
        }
	}	
}
