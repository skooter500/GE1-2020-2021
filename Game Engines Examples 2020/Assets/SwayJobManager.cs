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
    NativeArray<float> angle;
    NativeArray<float> frequency;

    int maxJobs = 30000;
    int numJobs = 0;

    JobHandle jh;

    public static SwayJobManager Instance;

    public void Awake()
    {
        transforms = new TransformAccessArray(0, -1);
        theta = new NativeArray<float>(maxJobs, Allocator.Persistent);
        angle = new NativeArray<float>(maxJobs, Allocator.Persistent);
        frequency = new NativeArray<float>(maxJobs, Allocator.Persistent);
        Instance = this;

    }

    public void Add(Sway sway)
    {
        transforms.capacity = transforms.length + 1;
        transforms.Add(sway.transform);
        theta[numJobs] = 0;
        angle[numJobs] = sway.angle;
        frequency[numJobs] = sway.frequency;
        numJobs++;
    }

    public void OnDestroy()
    {
        transforms.Dispose();
        theta.Dispose();
        angle.Dispose();
        frequency.Dispose();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        jh.Complete();
    }

    // Update is called once per frame
    void Update()
    {
        var job = new SwayJob()
        {
            timeDelta = Time.deltaTime
            ,angle = this.angle
            ,frequency = this.frequency
            ,theta = this.theta
        };
        jh = job.Schedule(transforms);
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
        transform.rotation = Quaternion.AngleAxis(Mathf.Sin(theta[i]) * angle[i], right);
        theta[i] += Mathf.PI * 2.0f * frequency[i] * timeDelta;
    }
}


