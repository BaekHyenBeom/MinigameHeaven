using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * Speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }
}
