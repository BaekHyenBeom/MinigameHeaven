using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public float minSpeed = 100f;  // 최소 속도
    public float maxSpeed = 300f;  // 최대 속도
    private float rotationSpeed;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // 줄의 머티리얼 설정
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // 줄의 위치 설정
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(-1, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(1, 0, 0));

        // 최소 속도와 최대 속도 사이에서 랜덤한 회전 속도를 설정합니다.
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 200 * Time.deltaTime));

        // 줄을 회전시킵니다.
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

}
