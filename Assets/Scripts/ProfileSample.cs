using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class ProfileSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DoSomething();
    }


    void DoSomething()
    {
        Profiler.BeginSample("Profiler Sample");
        List<int> listOfInts = new List<int>();
        for(int i = 0; i < 1000000; ++i)
        {
            listOfInts.Add(i);
        }
        Profiler.EndSample();

    }


}
