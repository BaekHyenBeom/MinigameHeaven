using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRope : Character
{
    public float jumpPower;
    bool jump = false;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void JUMP_J()
    {
        //점프했을 때 
        if (jump && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }
    private void FixedUpdate()
    {
        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("줄 걸림");
            OnDamaged();
        }
    }

    public void OnDamaged()
    {
        gameObject.layer = 8; // PlayerDamaged
        anim.SetBool("isDamaged", true);
        Invoke("OffDamagedAnim", 0.5f);
        Invoke("OffDamaged", 3f);
    }

    public void OffDamagedAnim()
    {
        anim.SetBool("isDamaged", false);
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);

    }

    public void OffDamaged()
    {
        gameObject.layer = 7; // Player
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    

    public override void IdleAnim()
    {
        base.IdleAnim();
    }

    public override void MoveAnim()
    {
        base.MoveAnim();
    }

    public override void JumpAnim()
    {
        base.JumpAnim();
    }

    public override void HitAnim()
    {
        base.HitAnim();
    }

    public override void GameOverAnim()
    {
        base.GameOverAnim();
    }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("JumpRope"))
            {
                Debug.Log("캐릭터가 줄넘기와 충돌했습니다!");
                // 필요한 경우 추가 동작을 여기에 구현
            }
        }
    }

