using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCompPerformance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 1000000;

        Transform test;
        using(new CustomTimer("GetComponent(string)", num))
        {
            for(var i = 0; i < num; i++)
            {
                test = (Transform)GetComponent("Transform");
            }
        }

        using(new CustomTimer("GetComponent<ComponentName>", num))
        {
            for(var i = 0; i < num; i++)
            {
                test = GetComponent<Transform>();
            }
        }

        using(new CustomTimer("GetComponent(typeof(ComponentName))", num))
        {
            for (var i = 0; i < num; i++)
            {
                test = (Transform)GetComponent(typeof(Transform));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
