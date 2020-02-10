using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePerformance : MonoBehaviour
{

    private int count = 0;
    private float delay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        int num = 100000;
        using (new CustomTimer("Coroutine Test ", num))
        {
            for(int i = 0; i < num; i++)
                StartCoroutine(ProcessCoroutine());
        }

        //InvokeRepeatingの方が若干速い
        using (new CustomTimer("InvokeRepeating Test ", num))
        {
            for (int i = 0; i < num; i++)
                InvokeRepeating("Process", 0f, delay);
        }
    }



    void Process()
    {
        count++;
    }

    IEnumerator ProcessCoroutine()
    {
        while(true)
        {
            Process();
            yield return new WaitForSeconds(delay);
        }
    }


}
