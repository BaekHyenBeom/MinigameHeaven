using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    [Header("Speed Settings")]
    public float minMoveSpeed = 0.5f; // 최소 이동 속도
    public float maxMoveSpeed = 1.5f; // 최대 이동 속도
    public float changeInterval = 2.0f; // 속도 변경 간격 (초 단위)

    [Header("Movement Range Settings")]
    public float moveRange = 3.0f; // 이동 범위 (유닛 단위)
    public Vector3 areaMinBounds = new Vector3(0f, 0f, 0f); // 이동 가능한 최소 좌표
    public Vector3 areaMaxBounds = new Vector3(0f, -1.8f, 0f); // 이동 가능한 최대 좌표

    private Vector3 initialPosition;
    private bool movingUp = true;
    private float moveSpeed;
    private float timeSinceLastChange;

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 저장
        SetRandomSpeed(); // 초기 속도 설정
        timeSinceLastChange = 0.0f; // 시간 초기화
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeInterval)
        {
            SetRandomSpeed();
            timeSinceLastChange = 0.0f;
        }

        MoveRope();
    }

    void SetRandomSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void MoveRope()
    {
        // 현재 위치를 기준으로 위아래로 움직이게 함
        Vector3 position = transform.position;
        if (movingUp)
        {
            position.y += moveSpeed * Time.deltaTime;
            if (position.y >= initialPosition.y + moveRange || position.y >= areaMaxBounds.y)
            {
                movingUp = false;
            }
        }
        else
        {
            position.y -= moveSpeed * Time.deltaTime;
            if (position.y <= initialPosition.y - moveRange || position.y <= areaMinBounds.y)
            {
                movingUp = true;
            }
        }

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
            // 필요한 경우 추가 동작을 여기에 구현
        }
    }

}
