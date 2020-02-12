using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;

public class JobCubeManager : MonoBehaviour
{

    public float cubeSpacing = 0.1f;
    public int width = 10;
    public int height = 10;

    public GameObject cubePrefab;

    TransformAccessArray transformAccessArray;
    JobHandle jobHandle;
    NativeList<float> speeds;


    // Start is called before the first frame update
    void Start()
    {
        transformAccessArray = new TransformAccessArray(0, -1);
        speeds = new NativeList<float>(1, Allocator.Persistent);
        SpawnCubes();
    }

    void SpawnCubes()
    {
        Vector3 position = new Vector3();
        while(position.x < width)
        {
            while(position.y < height)
            {
                var newCube = Instantiate(cubePrefab);
                newCube.transform.position = position;
                position = new Vector3(position.x, position.y + cubeSpacing, 0f);
                transformAccessArray.Add(newCube.transform);
                speeds.Add(Random.Range(25.0f, 50.0f));
            }
            position = new Vector3(position.x + cubeSpacing, 0f, 0f);
        }

    }


    // Update is called once per frame
    void Update()
    {
        jobHandle.Complete();
        if(jobHandle.IsCompleted)
        {
            var rotatorJob = new RotatorJob()
            {
                deltaTime = Time.deltaTime,
                speeds = speeds
            };
            jobHandle = rotatorJob.Schedule(transformAccessArray);
            JobHandle.ScheduleBatchedJobs();

        }
    }
}
