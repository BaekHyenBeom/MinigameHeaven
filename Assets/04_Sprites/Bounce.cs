using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<=0)  //y<=0 �� �÷��̾ �Ʒ��� �̵��ϴ��� �ƴϸ� 0 ���� ������� Ȯ���ϴ°�
        {
            //�ʱ�ȭ //�����
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);


            //float ranx = Random.Range(-2.2f, 2.2f);
            //float rany = Random.Range(StageManager.Instance.prey + 0.5f, StageManager.Instance.prey + 2);

            //transform.position = new Vector2(ranx, rany);

            //StageManager.Instance.prey = rany;
          
        }


    }
}
