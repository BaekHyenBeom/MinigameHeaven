using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    [Header("Speed Settings")]
    public float minMoveSpeed = 0.1f; // �ּ� �̵� �ӵ�
    public float maxMoveSpeed = 1.0f; // �ִ� �̵� �ӵ�
    public float speedChangeRate = 0.5f; // �ӵ� ���� ����

    [Header("Movement Range Settings")]
    public float moveRangeY = 0.18f; // Y�� �̵� ����
    public Vector3 areaMinBounds = new Vector3(-5f, -0.18f, -5f); // �̵� ������ �ּ� ��ǥ
    public Vector3 areaMaxBounds = new Vector3(5f, 0f, 5f); // �̵� ������ �ִ� ��ǥ

    private float moveSpeed;
    private Vector3 direction;

    void Start()
    {
        SetRandomDirection(); // �ʱ� ���� ����
        moveSpeed = minMoveSpeed; // �ʱ� �ӵ� ����
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
            0, // Y�� ������ ����
            Random.Range(-1f, 1f)
        ).normalized; // ������ ���� ���� �� ����ȭ
    }

    void AdjustSpeed()
    {
        // �ð��� ���� �ӵ��� õõ�� ������Ű�� ���ҽ�Ŵ
        moveSpeed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, Mathf.PingPong(Time.time * speedChangeRate, 1));
    }

    void MoveRope()
    {
        Vector3 position = transform.position;
        position += direction * moveSpeed * Time.deltaTime;

        // �̵� ������ ������ ���� �ʵ��� ��ġ�� ������
        position.x = Mathf.Clamp(position.x, areaMinBounds.x, areaMaxBounds.x);
        position.y = Mathf.Clamp(position.y, areaMinBounds.y, areaMaxBounds.y);
        position.z = Mathf.Clamp(position.z, areaMinBounds.z, areaMaxBounds.z);

        transform.position = position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�ٳѱⰡ ĳ���Ϳ� �浹�߽��ϴ�!");
        }
    }

}
