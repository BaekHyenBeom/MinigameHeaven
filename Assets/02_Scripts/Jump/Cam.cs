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

        // 플레이어의 Y 속도가 양수일 때만 카메라가 따라가도록 설정
        if (playerVelocityY >= 0.01f)
        {
            Vector3 targetPosition = playerTransform.position + camOffset;

            // 플레이어의 Y 속도에 따라 카메라의 Y 위치를 조정
            targetPosition.y += playerVelocityY * followSpeed * Time.deltaTime;

            // 카메라의 위치를 부드럽게 조정하기 위해 Lerp 사용
            camT.position = Vector3.Lerp(camT.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
