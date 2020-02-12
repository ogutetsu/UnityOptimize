using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringPerformance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 10000;
        using(new CustomTimer("string + ", num))
        {
            string a = "";
            for(int i = 0; i < num; i++)
            {
                a += i.ToString();
            }
        }
        using (new CustomTimer("string concat ", num))
        {
            string a = "";
            for (int i = 0; i < num; i++)
            {
                a = string.Concat(a, i.ToString());
            }
        }
        //ここまで極端なものは無いにしろ、文字列の連結はStringBuilderの方が良い。
        using (new CustomTimer("StringBuilder", num))
        {
            StringBuilder sb = new StringBuilder("");
            
            for (int i = 0; i < num; i++)
            {
                sb.Append(i.ToString());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
