using Unity.Jobs;
using UnityEngine;
using Unity.Collections;

public struct SimpleJob : IJob
{
    public float number;

    public NativeArray<float> data;

    public void Execute()
    {
        data[0] += number;
    }

}
