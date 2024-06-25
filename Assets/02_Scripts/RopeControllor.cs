using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    [Header("Speed Settings")]
    public float minMoveSpeed = 0.1f; // 최소 이동 속도
    public float maxMoveSpeed = 1.0f; // 최대 이동 속도
    public float speedChangeRate = 0.5f; // 속도 변경 비율

    [Header("Movement Range Settings")]
    public float moveRangeY = 0.18f; // Y축 이동 범위
    public Vector3 areaMinBounds = new Vector3(-5f, -0.18f, -5f); // 이동 가능한 최소 좌표
    public Vector3 areaMaxBounds = new Vector3(5f, 0f, 5f); // 이동 가능한 최대 좌표

    private float moveSpeed;
    private Vector3 direction;

    void Start()
    {
        SetRandomDirection(); // 초기 방향 설정
        moveSpeed = minMoveSpeed; // 초기 속도 설정
    }

    void Update()
    {
        AdjustSpeed();
        MoveRope();
    }

    void SetRandomDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            0, // Y축 방향은 고정
            Random.Range(-1f, 1f)
        ).normalized; // 랜덤한 방향 설정 및 정규화
    }

    void AdjustSpeed()
    {
        // 시간에 따라 속도를 천천히 증가시키고 감소시킴
        moveSpeed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, Mathf.PingPong(Time.time * speedChangeRate, 1));
    }

    void MoveRope()
    {
        Vector3 position = transform.position;
        position += direction * moveSpeed * Time.deltaTime;

        // 이동 가능한 범위를 넘지 않도록 위치를 제한함
        position.x = Mathf.Clamp(position.x, areaMinBounds.x, areaMaxBounds.x);
        position.y = Mathf.Clamp(position.y, areaMinBounds.y, areaMaxBounds.y);
        position.z = Mathf.Clamp(position.z, areaMinBounds.z, areaMaxBounds.z);

        transform.position = position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("줄넘기가 캐릭터와 충돌했습니다!");
        }
    }

}
