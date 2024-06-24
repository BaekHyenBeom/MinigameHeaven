using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
           // Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <=0.01f)  //y<=0 는 플레이어가 아래로 이동하는지 아니면 0 에서 멈췄는지 확인하는것
        {

            Debug.Log("충돌");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f, ForceMode2D.Force);
            
            
            //Rigidbody2D cloRb = collision.gameObject.GetComponent<Rigidbody2D>();

            //// 중력이 적용되어 있는지 확인
            //if (cloRb.gravityScale > 0)
            //{
            //    //  힘을 가해서 점프시키기
            //    cloRb.velocity = new Vector2(cloRb.velocity.x, 0f);  // 현재 y 속도를 초기화
            //    cloRb.AddForce(Vector2.up * 400f, ForceMode2D.Force);
            //}




            //float ranx = Random.Range(-2.2f, 2.2f);
            //float rany = Random.Range(StageManager.Instance.prey + 0.5f, StageManager.Instance.prey + 2);

            //transform.position = new Vector2(ranx, rany);

            //StageManager.Instance.prey = rany;

        }


    }
}
