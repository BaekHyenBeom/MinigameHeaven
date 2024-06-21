using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

 

    public float Speed;
    private int startIndex;
    private int endIndex;
    public Transform[] sprties;



    float viewHigth;


    private void Awake()
    {
        viewHigth = 12;  //배경 길이

        refresh();


    }
    void Update()
    {
        Vector3 curpos =transform.position;
        Vector3 nextpos = Vector3.down*Speed * Time.deltaTime;
        transform.position = curpos+ nextpos;


        if (sprties[endIndex].position.y < viewHigth * (-1))
        {
            Vector3 start = sprties[startIndex].localPosition;
       
            sprties[endIndex].transform.localPosition= start+ Vector3.up * viewHigth;


            if (endIndex == 0 )
            {
                refresh();
            }
            else
            {
            startIndex = endIndex;
                endIndex = startIndex - 1;
            }

            //startIndex = endIndex;
            //endIndex = startIndex - 1;
            //if (endIndex== -1)
            //{
            //    endIndex = sprties.Length-1;
            //}
        }

       
    }



    void refresh()
    {
        startIndex = 0;
        endIndex = sprties.Length - 1;

    }
}
