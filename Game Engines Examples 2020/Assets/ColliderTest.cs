using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Collision enter!");
        Debug.Log(c.gameObject.tag);
        if (c.gameObject.tag == "Ground")
        {
            Debug.Log("Collides with ground");
        }
    }

    void OnCollisionStay(Collision c)
    {
        Debug.Log("Collision Stay");
    }

    void OnCollisionExit(Collision c)
    {
        Debug.Log("Collision Exit");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   


}
