using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


public class ECSJobManager : MonoBehaviour
{

    public float cubeSpacing = 0.1f;
    public int width = 10;
    public int height = 10;
    public GameObject cubePrefab;

    EntityManager entityManager;

    // Start is called before the first frame update
    void Start()
    {
        entityManager = World.Active.EntityManager;
        SpawnCubes();
    }

    void SpawnCubes()
    {
        Vector3 position = new Vector3(0,0,0);
        var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(cubePrefab, World.Active);

        while (position.x < width)
        {
            while (position.y < height)
            {
                var instance = entityManager.Instantiate(entityPrefab);

                position = new Vector3(position.x, position.y + cubeSpacing, 0f);
                entityManager.SetComponentData(instance, new Translation() { Value = position });
                entityManager.SetComponentData(instance, new RotationSpeed() { value = math.radians(UnityEngine.Random.Range(25.0f, 50.0f)) });
            }
            position = new Vector3(position.x + cubeSpacing, 0f, 0f);
        }
    }




}
