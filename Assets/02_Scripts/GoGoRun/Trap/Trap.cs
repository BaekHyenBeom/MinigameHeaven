using System.Collections;
using UnityEngine;


public enum TrapType
{
    Top,
    Bottom,
    SpikeHead
}
public class Trap : MonoBehaviour
{
    [field : SerializeField]
    protected Animator animator;

    public TrapType type;


    public LayerMask layerMask;

    public float moveSpeed = 2.5f;

    public float checkRate = 0.05f;
    private float lastCheckTime;

    public Transform rayPos;

    private bool isPause = false;
    private bool isCollision = false;

    RaycastHit2D hit;
    RaycastHit2D hit2;

    private Coroutine co_Pause;
    private Coroutine co_TrapHeadAttack;

    private void Start()
    {
        moveSpeed = 2.0f;
    }


    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(!isPause)
        {
            if (Time.time - lastCheckTime > checkRate)
            {
                lastCheckTime = Time.time;

                if(type != TrapType.SpikeHead)
                {
                    hit = Physics2D.Raycast(rayPos.position, Vector2.left, 2.0f, layerMask);
                    hit2 = Physics2D.Raycast(rayPos.position, Vector2.up, 2.0f, layerMask);
                    if (hit || hit2)
                    {
                        if (hit.Equals(this))
                        {
                            return;
                        }
                        else
                        {
                            moveSpeed = 0f;
                        }
                    }
                    else
                    {
                        moveSpeed = 2.5f;
                    }
                }
            }

            SpikeHeadAttack();
        }

    }
    
    private void SpikeHeadAttack()
    {
        if (type == TrapType.SpikeHead)
        {
            if (isCollision)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 0.1f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -6.25f, transform.position.z), 0.25f);
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.curMiniGameScript.GameOver();
        }
        else if(collision.CompareTag("Trap") && type == TrapType.Top )
        {
            if(co_Pause != null)
                StopCoroutine(co_Pause);

            co_Pause = StartCoroutine(Pause());
        }
        else if(collision.CompareTag("Level") && type == TrapType.SpikeHead)
        {
            isCollision = true;
            SoundManager.Instance.PlaySfxSound("SpikeHeadHit");
            Invoke(nameof(SpikeAttackAgain), 5f);
        }
    }

    private void SpikeAttackAgain()
    {
        isCollision = false;
    }

    private IEnumerator Pause()
    {
        isPause = true;
        moveSpeed = 0;
        float waitTime = Random.Range(1.0f, 3.0f);

        yield return CoroutineHelper.WaitForSeconds(waitTime);

        moveSpeed = 2.5f;

        isPause = false;
        yield break;
    }

}
