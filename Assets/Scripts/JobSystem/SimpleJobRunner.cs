using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public class SimpleJobRunner : MonoBehaviour
{

    public float number = 5;

    private NativeArray<float> data;

    private JobHandle simpleJobHandle;

    // Start is called before the first frame update
    void Start()
    {
        data = new NativeArray<float>(1, Allocator.Persistent);
        data[0] = 2;
        SimpleJob simpleJob = new SimpleJob
        {
            number = this.number,
            data = this.data
        };

        simpleJobHandle = simpleJob.Schedule();

        JobHandle.ScheduleBatchedJobs();

        simpleJobHandle.Complete();

        if(simpleJobHandle.IsCompleted)
        {
            Debug.Log(simpleJob.data[0]);
        }

        data.Dispose();

    }

}
