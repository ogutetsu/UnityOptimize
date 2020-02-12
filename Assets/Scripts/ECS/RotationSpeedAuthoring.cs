using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Mathematics;


[RequiresEntityConversion]
public class RotationSpeedAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float rotationSpeed = 35f;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new RotationSpeed { value = math.radians(rotationSpeed) };
        dstManager.AddComponentData(entity, data);
    }

}
