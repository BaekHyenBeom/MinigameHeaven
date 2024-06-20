using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<=0)  //y<=0 는 플레이어가 아래로 이동하는지 아니면 0 에서 멈췄는지 확인하는것
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);
        }
    }
}
