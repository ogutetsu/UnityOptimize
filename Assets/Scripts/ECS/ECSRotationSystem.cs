using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class ECSRotationSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        ECSRotatorJob rotatorJob = new ECSRotatorJob()
        {
            deltaTime = Time.deltaTime
        };
        return rotatorJob.Schedule(this, inputDeps);
    }


}
