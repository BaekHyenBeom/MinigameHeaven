using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
           // Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <=0.01f)  //y<=0 �� �÷��̾ �Ʒ��� �̵��ϴ��� �ƴϸ� 0 ���� ������� Ȯ���ϴ°�
        {

            Debug.Log("�浹");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f, ForceMode2D.Force);
            
            
            //Rigidbody2D cloRb = collision.gameObject.GetComponent<Rigidbody2D>();

            //// �߷��� ����Ǿ� �ִ��� Ȯ��
            //if (cloRb.gravityScale > 0)
            //{
            //    //  ���� ���ؼ� ������Ű��
            //    cloRb.velocity = new Vector2(cloRb.velocity.x, 0f);  // ���� y �ӵ��� �ʱ�ȭ
            //    cloRb.AddForce(Vector2.up * 400f, ForceMode2D.Force);
            //}




            //float ranx = Random.Range(-2.2f, 2.2f);
            //float rany = Random.Range(StageManager.Instance.prey + 0.5f, StageManager.Instance.prey + 2);

            //transform.position = new Vector2(ranx, rany);

            //StageManager.Instance.prey = rany;

        }


    }
}
