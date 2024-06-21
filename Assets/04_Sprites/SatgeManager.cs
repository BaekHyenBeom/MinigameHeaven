using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatgeManager : MonoBehaviour
{
    public GameObject cloudpre;
    public int cloudcount;

    float prex = -100;
    float prey = -2.74f;


    int check = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cloudcount; i++)
        {
            float ranx = Random.Range(-2.2f, 2.2f);
            float rany = Random.Range(prey+0.5f, prey+2);  // «√∑π¿ÃæÓ ¡¬«•
           
                                                  //x, y  <0.5
            //while (prex - ranx < 1.0f && prey -rany <1.5f)
            //{
            //    ranx = Random.Range(-2.2f, 2.2f);
              
            //    check++;
            //    if (check >100)
            //    {
            //        check = 0;
            //        Debug.Log(" ≈ª√‚");
            //        break;
            //    }
            //}
                Instantiate(cloudpre,new Vector2(ranx , rany), Quaternion.identity);
            prex = ranx;
            prey = rany;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
