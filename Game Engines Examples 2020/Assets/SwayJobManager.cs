using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class SwayJobManager : MonoBehaviour
{
 
    TransformAccessArray transforms;
    NativeArray<float> theta;
    NativeArray<float> frequency;
    NativeArray<float> angle;

    int maxJobs = 30000;
    int numJobs = 0;

    JobHandle jobHandle;
 
    public static SwayJobManager Instance;

    public void Add(Sway sway)
    {
        transforms.capacity = transforms.length + 1;
        transforms.Add(sway.transform);
        theta[numJobs] = 0;
        frequency[numJobs] = sway.frequency;
        angle[numJobs] = sway.angle;
        numJobs ++;
    }


    public void Awake()
    {
        Instance = this;

        transforms = new TransformAccessArray(0);
        theta = new NativeArray<float>(maxJobs, Allocator.Persistent);
        frequency = new NativeArray<float>(maxJobs, Allocator.Persistent);
        angle = new NativeArray<float>(maxJobs, Allocator.Persistent);

    }

    public void OnDestroy()
    {
        transforms.Dispose();
        theta.Dispose();
        frequency.Dispose();
        angle.Dispose();
    }

 
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        jobHandle.Complete();
    }
 
    // Update is called once per frame
    void Update()
    {
        var job = new SwayJob()
        {
            theta = this.theta
            , frequency = this.frequency
            , angle = this.angle
            , timeDelta = Time.deltaTime
        };
        jobHandle = job.Schedule(transforms);
    }
}

public struct SwayJob : IJobParallelForTransform
{
    public NativeArray<float> theta;
    public NativeArray<float> angle;
    public NativeArray<float> frequency;
    public float timeDelta;

    public void Execute(int i, TransformAccess transform)
    {
        Vector3 right = transform.rotation * Vector3.right;
        transform.rotation = Quaternion.AngleAxis(Mathf.Sin(theta[i] * angle[i]), right);
        theta[i] += Mathf.PI * 2.0f * frequency[i] * timeDelta;
    }
}

