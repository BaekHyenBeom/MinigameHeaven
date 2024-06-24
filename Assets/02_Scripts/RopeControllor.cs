using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    [Header("Speed Settings")]
    public float minMoveSpeed = 0.5f; // �ּ� �̵� �ӵ�
    public float maxMoveSpeed = 1.5f; // �ִ� �̵� �ӵ�
    public float changeInterval = 2.0f; // �ӵ� ���� ���� (�� ����)

    [Header("Movement Range Settings")]
    public float moveRange = 3.0f; // �̵� ���� (���� ����)
    public Vector3 areaMinBounds = new Vector3(0f, 0f, 0f); // �̵� ������ �ּ� ��ǥ
    public Vector3 areaMaxBounds = new Vector3(0f, -1.8f, 0f); // �̵� ������ �ִ� ��ǥ

    private Vector3 initialPosition;
    private bool movingUp = true;
    private float moveSpeed;
    private float timeSinceLastChange;

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
        SetRandomSpeed(); // �ʱ� �ӵ� ����
        timeSinceLastChange = 0.0f; // �ð� �ʱ�ȭ
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
        // ���� ��ġ�� �������� ���Ʒ��� �����̰� ��
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
            // �ʿ��� ��� �߰� ������ ���⿡ ����
        }
    }

}
