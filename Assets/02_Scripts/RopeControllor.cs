using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RopeControllor : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public float minSpeed = 100f;  // �ּ� �ӵ�
    public float maxSpeed = 300f;  // �ִ� �ӵ�
    private float rotationSpeed;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // ���� ��Ƽ���� ����
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // ���� ��ġ ����
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(-1, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(1, 0, 0));

        // �ּ� �ӵ��� �ִ� �ӵ� ���̿��� ������ ȸ�� �ӵ��� �����մϴ�.
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 200 * Time.deltaTime));

        // ���� ȸ����ŵ�ϴ�.
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

}
