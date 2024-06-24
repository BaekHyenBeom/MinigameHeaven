using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform camT;
    [SerializeField] private Vector3 camOffset;
    private Transform playerTransform;
    [SerializeField] private float followSpeed = 5f;

    void Start()
    {
        if (Camera.main != null)
        {
            camT = Camera.main.transform;
            playerTransform = transform;
        }
    }

    void LateUpdate()
    {
        if (playerTransform == null || camT == null)
            return;

        float playerVelocityY = playerTransform.GetComponent<Rigidbody2D>().velocity.y;

        // �÷��̾��� Y �ӵ��� ����� ���� ī�޶� ���󰡵��� ����
        if (playerVelocityY >= 0.01f)
        {
            Vector3 targetPosition = playerTransform.position + camOffset;

            // �÷��̾��� Y �ӵ��� ���� ī�޶��� Y ��ġ�� ����
            targetPosition.y += playerVelocityY * followSpeed * Time.deltaTime;

            // ī�޶��� ��ġ�� �ε巴�� �����ϱ� ���� Lerp ���
            camT.position = Vector3.Lerp(camT.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
