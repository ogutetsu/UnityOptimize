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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            List<int> listOfInts = new List<int>();
            const int numTests = 1000000;
            using(new CustomTimer("Controlled Test", numTests))
            {
                for(int i = 0; i < numTests; i++)
                {
                    listOfInts.Add(i);
                }
            }
        }
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
