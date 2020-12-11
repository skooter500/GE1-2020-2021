using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class SwayJobManager : MonoBehaviour
{
 
 
    public static SwayJobManager Instance;

    public void Awake()
    {
        Instance = this;

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

public struct SwayJob : IJobParallelForTransform
{
    public NativeArray<float> theta;
    public NativeArray<float> angle;
    public NativeArray<float> frequency;
    public float timeDelta;

    public void Execute(int i, TransformAccess transform)
    {
    }
}

