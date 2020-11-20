using UnityEngine;
using System.Collections;

public class PhysicsFactory : MonoBehaviour {

    public LayerMask groundLM;
    public GameObject wormPrefab;
    void CreateTower(float radius, int height, int segments, Vector3 point)
    {
        // Use a nested loop to create each of the bricks of the tower
        // The outer loop will go from 0 to height
        // The inner loop will go from 0 to number of segments
        // Use CreateBrick to create each of the bricks of the tower
        // Dont forget to rotate each brick. You can use a quaternion for this
        // For each row, you will need to offeet the rotation of each brick by half
        // So that the bricks overlap
        // Assign random colors to each brick                
    }

    void CreateWorm(Vector3 point, Quaternion q)
    {
        GameObject worm = GameObject.Instantiate<GameObject>(wormPrefab, point, q);
    }

    GameObject CreateCylinder(float x, float y, float z, float diameter, float width, Quaternion q)
    {
        GameObject wheel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        wheel.transform.localScale = new Vector3(diameter, width, diameter);
        wheel.transform.position = new Vector3(x, y, z);
        wheel.transform.rotation = q;
        wheel.GetComponent<Renderer>().material.color = Utilities.RandomColor();
        Rigidbody rigidBody = wheel.AddComponent<Rigidbody>();
        return wheel;
    }

    GameObject CreateCar(float x, float y, float z)
    {
        float width = 15;
        float height = 2;
        float length = 5;
        float wheelWidth = 1;
        float wheelDiameter = 4;
        float wheelOffset = 2.0f;

        Vector3 position = new Vector3(x, y, z);

        // Use CreateBrick to create the chassis
        // Calculate the wheel positions offset from the center of the brick.
        // Dont worry about rotating the car, just calculate the positions
        // relative to the center of the car
        // It needs to be rotated 90 degrees around the right vector. You can do that 
        // using the quaternion q below
        // Set the hinge anchor to be the vector (0, 1, 0);
        // And set autoConfigureConnectedAnchor to be true


        GameObject chassis = CreateBrick(x, y, z, width, height, length);
        Quaternion q = Quaternion.AngleAxis(90.0f, Vector3.right);

        Vector3[] wheelPositions = new Vector3[4];
        // Assign values to the 4 wheel positions
        // Calculate the wheel positions offset from the center of the chassis.
        
        foreach (Vector3 wheelPosition in wheelPositions)
        {
            // Call CreateCylinder to create each of the wheels at the appropriate positions            
            // Use the values in the array and the Quaternion q to rotate the wheels            
            // Add a Hingejoint to each of the wheels and connect it to the chassis
            // By setting the connectedBody property
            // Set the axis of the HingeJoint to be Vector3.up. You would think it should
            // be Vector3.right, but because the cylinder by default is like a flat disc
            // and we rotate it by q when we are creating it
            // so the axis is local to the wheel
        }        
        return chassis;       
    }   


    // Use this for initialization
    void Start () {       
    }

    GameObject CreateGear(float x, float y, float z, float diameter, int numCogs)
    {
        Quaternion q = Quaternion.AngleAxis(90, Vector3.right);
        GameObject cyl = CreateCylinder(x, y, z, diameter, 1.0f, q);

        float radius = 1 + (diameter * 0.5f);
        float thetaInc = (Mathf.PI * 2.0f) / numCogs;
        for (int i = 0; i < numCogs; i++)
        {
            
            float theta = thetaInc * i;
            Vector3 cogPos = new Vector3();
            cogPos.x = x + (Mathf.Sin(theta) * radius);
            cogPos.y = y + (Mathf.Cos(theta) * radius);  
            cogPos.z = z;

            // Make the cog rotation
            Quaternion cogQ = Quaternion.AngleAxis(- theta * Mathf.Rad2Deg, Vector3.forward);
            
            GameObject cog = CreateBrick(cogPos.x, cogPos.y, cogPos.z);
            cog.transform.rotation = cogQ;
            FixedJoint joint = cog.AddComponent<FixedJoint>();
            joint.connectedBody = cyl.GetComponent<Rigidbody>();
            joint.autoConfigureConnectedAnchor = true;
        }
        return cyl;
    }

    GameObject CreateBrick(float x, float y, float z, float xScale = 1.0f, float yScale = 1.0f, float zScale = 1.0f)
    {
        GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
        brick.tag = "brick";
        brick.transform.localScale = new Vector3(xScale, yScale, zScale);
        brick.transform.position = new Vector3(x, y, z);
        brick.GetComponent<Renderer>().material.color = Utilities.RandomColor();
        Rigidbody rigidBody = brick.AddComponent<Rigidbody>();
        rigidBody.mass = 1.0f;
        return brick;
    }

    void CreateWall(int width, int height)
    {
        
        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject brick = CreateBrick(x - (width / 2), 0.5f + y * 1.1f, 0);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateWall(10, 10);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastHit raycastHit;
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "groundPlane")
                {
                    Vector3 pos = raycastHit.point;
                    pos.y = 10;
                    CreateCar(pos.x, pos.y, pos.z);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit raycastHit;
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "groundPlane")
                {
                    Vector3 pos = raycastHit.point;
                    pos.y = 20;
                    CreateGear(pos.x, pos.y, pos.z, 10, 10);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            RaycastHit rch;
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");            
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out rch, 100))
            {
                Vector3 p = rch.point;
                p.y = 0.5f;
                CreateTower(3, 10, 12, p);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            RaycastHit rch;
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");            
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out rch, 100, groundLM))
            {
                Vector3 p = rch.point;
                p.y = 5;
                Quaternion q = mainCamera.transform.rotation;
                Vector3 xyz = q.eulerAngles;
                q = Quaternion.Euler(0, xyz.y + 90, 0);
                CreateWorm(p, q);
            }
        }
    }
}
