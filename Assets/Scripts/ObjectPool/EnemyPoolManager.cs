using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPool : IPoolableObject
{
    public void New()
    {
        Debug.Log("New Enemy");
    }

    public void Respawn()
    {
        Debug.Log("Respawn Enemy");
    }
}



public class EnemyPoolManager : MonoBehaviour
{

    private ObjectPool<EnemyPool> Enemyies = new ObjectPool<EnemyPool>(50);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("respawn");

        for(int i = 0; i < 50; i++)
        {
            EnemyPool e = Enemyies.Spawn();
        }


        Debug.Log("new enemy");

        for (int i = 0; i < 50; i++)
        {
            EnemyPool e = Enemyies.Spawn();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
