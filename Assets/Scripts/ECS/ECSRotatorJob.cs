using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public struct ECSRotatorJob : IJobForEach<Rotation, RotationSpeed>
{

    [ReadOnly]
    public float deltaTime;

    public void Execute(ref Rotation rotation, ref RotationSpeed rotationSpeed)
    {
        rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), rotationSpeed.value * deltaTime));
    }

}
