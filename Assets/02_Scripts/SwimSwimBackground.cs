using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSwimBackground : MonoBehaviour
{
    public float speed;
    public Transform[] backgrounds;

    float leftPosX = -7.898f;
    float rightPosX = 27.644f;
    // float xScreenHalfSize;
    // float yScreenHalfSize;

    void Start()
    {
        // yScreenHalfSize = Camera.main.orthographicSize;
        // xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        // leftPosX = -(xScreenHalfSize * 2) -8f;
        // rightPosX = xScreenHalfSize * 2 * backgrounds.Length + 27.65f;
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}