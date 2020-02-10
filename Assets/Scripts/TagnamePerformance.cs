using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagnamePerformance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = 1000000;

        if(Input.GetKeyDown(KeyCode.A))
        {
            using (new CustomTimer("tag eqauls ", num))
            {
                for (int i = 0; i < num; i++)
                {
                    if (gameObject.tag == "Player")
                    {
                        ;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //CompareTagでの比較が速度、メモリともに良い
            using (new CustomTimer("CompareTag", num))
            {
                for (int i = 0; i < num; i++)
                {
                    if (gameObject.CompareTag("Player"))
                    {
                        ;
                    }
                }
            }
        }


    }
}
